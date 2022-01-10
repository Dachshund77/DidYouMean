using System.Collections.Generic;

namespace DidYouKnow
{
    public interface IAlphabetProvider{

        Dictionary<char,double> GetData();

    }
}