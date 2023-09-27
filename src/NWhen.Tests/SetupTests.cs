namespace NWhen.Tests
{
    public class SetupTests
    {
        [Fact]
        public void ShouldSetupStartDate()
        {
            var date = new DateTime();

            var sut = new When();
            sut.SetStartDate(date);

            Assert.Equal(date, sut.StartDate);
        }
    }
}
