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

            svc.Login("tester", "bad");
            svc.Login("tester", "bad");
            var r3 = svc.Login("tester", "bad");
            Assert.False(r3.Status);
            var rem = svc.GetRemainingLockTime("tester");
            Assert.NotNull(rem);
        }

        [Fact]
        public void UnlockUserResets()
        {
            var svc = AuthService.Instance;
            svc.ClearAllAttempts();

            svc.Login("temp", "bad");
            svc.Login("temp", "bad");
            svc.Login("temp", "bad");
            Assert.NotNull(svc.GetRemainingLockTime("temp"));

            svc.UnlockUser("temp");
            Assert.Null(svc.GetRemainingLockTime("temp"));
            Assert.Equal(0, svc.GetAttempts("temp"));
        }
    }
}
