using System;
using Xunit;
using TelkomMedika.Services;

namespace TelkomMedika.Tests
{
    public class AuthServiceTests
    {
        [Fact]
        public void SuccessResetsAttempts()
        {
            var svc = AuthService.Instance;
            svc.ClearAllAttempts();

            var r1 = svc.Login("dokter", "wrong");
            var r2 = svc.Login("dokter", "wrong");
            Assert.False(r1.Status);
            Assert.False(r2.Status);
            Assert.Equal(2, svc.GetAttempts("dokter"));

            var good = svc.Login("dokter", "123");
            Assert.True(good.Status);
            Assert.Equal(0, svc.GetAttempts("dokter"));
        }

        [Fact]
        public void FailuresIncrementAndLock()
        {
            var svc = AuthService.Instance;
            svc.ClearAllAttempts();

            svc.Login("dokter", "bad");
            svc.Login("dokter", "bad");
            var r3 = svc.Login("dokter", "bad");
            Assert.False(r3.Status);
            var rem = svc.GetRemainingLockTime("dokter");
            Assert.NotNull(rem);
        }

        [Fact]
        public void UnlockUserResets()
        {
            var svc = AuthService.Instance;
            svc.ClearAllAttempts();

            svc.Login("admin", "bad");
            svc.Login("admin", "bad");
            svc.Login("admin", "bad");
            Assert.NotNull(svc.GetRemainingLockTime("admin"));

            Assert.True(svc.UnlockUser("admin"));
            Assert.Null(svc.GetRemainingLockTime("admin"));
            Assert.Equal(0, svc.GetAttempts("admin"));
        }

        [Fact]
        public void UnknownUsernameReturnsNotRegistered()
        {
            var svc = AuthService.Instance;
            svc.ClearAllAttempts();

            var r = svc.Login("unknown", "anypassword");
            Assert.False(r.Status);
            Assert.Equal("Username tidak terdaftar!", r.Message);
            Assert.Equal(0, svc.GetAttempts("unknown"));
            Assert.Null(svc.GetRemainingLockTime("unknown"));
        }
    }
}
