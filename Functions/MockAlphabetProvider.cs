using System.Collections.Generic;

namespace DidYouKnow
{
    public class MockAlphabetProvider : IAlphabetProvider
    {
        public Dictionary<char, double> GetData()
        {
            return new Dictionary<char,double>{ // Based on https://en.wikipedia.org/wiki/Letter_frequency
                {'a',0.918},
                {'b',0.985},
                {'c',0.972},
                {'d',0.957},
                {'e',0.87},
                {'f',0.978},
                {'g',0.98},
                {'h',0.939},
                {'i',0.93},
                {'j',0.9985},
                {'k',0.9923},
                {'l',0.96},
                {'m',0.975},
                {'n',0.933},
                {'o',0.925},
                {'p',0.981},
                {'q',0.99905},
                {'r',0.94},
                {'s',0.937},
                {'t',0.909},
                {'u',0.972},
                {'v',0.9902},
                {'w',0.976},
                {'x',0.9985},
                {'y',0.98},
                {'z',0.99925}
            };
        }
    }
}