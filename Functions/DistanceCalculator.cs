using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.WebEncoders.Testing;

namespace DidYouKnow
{
    public class DistanceCalculator{

        private readonly IAlphabetProvider Alphabet;
        private readonly IDictionaryProvider Words;
        public DistanceCalculator(IAlphabetProvider alphabet, IDictionaryProvider words){
            Alphabet = alphabet;
            Words = words;
        }

        public Dictionary<string,double> CalculateDistance(string srcString, double maxDistance, double currDistance = 0){
            return CalculateDistance(srcString,srcString.Length - 1 , maxDistance, currDistance);
        }

        public Dictionary<string,double> CalculateDistance(string srcString, int charPointer, double maxDistance, double currDistance){  
            Dictionary<string,double> matchedWords= new Dictionary<string,double>();
            if(charPointer < 0){
                return matchedWords;
            }

            if(charPointer >= srcString.Length){
                srcString += ' ';
            }
            
            // Replace current index with each letter
            Dictionary<string,double> tmpDictionary= new Dictionary<string,double>();
            foreach (var c in Alphabet.GetData())
            {
                char[] tmpString = srcString.ToCharArray();
                tmpString[charPointer] = c.Key;
                if(currDistance + c.Value <= maxDistance){
                    tmpDictionary.Add(new string(tmpString), currDistance + c.Value);
                }
                 
            }

            //Check for match
            foreach (var w in tmpDictionary)
            {
                foreach (var d in Words.GetData())
                {
                    if(d.ToLower().Equals(w.Key.ToLower())){
                        matchedWords.TryAdd(w.Key,w.Value);
                    }
                }
            }
            // Else check for abort condition
            if(tmpDictionary.Count == 0){
                return matchedWords;
            }

            // NEXT
            foreach (var w in tmpDictionary)
            {
                foreach (var r in CalculateDistance(w.Key,charPointer-1,maxDistance, w.Value))
                {
                    matchedWords.TryAdd(r.Key,r.Value);
                }
            }

            foreach (var w in tmpDictionary)
            {
                foreach (var r in CalculateDistance(w.Key,charPointer+1,maxDistance, w.Value))
                {
                    matchedWords.TryAdd(r.Key,r.Value);
                }
            }        
            return matchedWords;
        }        
    }
}