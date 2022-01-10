namespace DidYouKnow
{
    public class MockDictionaryProvider : IDictionaryProvider
    {
        public string[] GetData()
        {
            return new []{"hello", "test", "tea"};
        }
    }
}