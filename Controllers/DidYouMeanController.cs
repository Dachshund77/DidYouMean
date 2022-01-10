using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DidYouKnow;
using Microsoft.AspNetCore.Mvc;

namespace DidYouMean
{
    [ApiController]
    [Route("[controller]")]
    public class DidYouMeanController: ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<Dictionary<string,double>>> DidYouMeanFunction (string src, double distance){
            Console.Out.WriteLine("Calculating distance of "+src);
            DistanceCalculator DistanceCalculator = new DistanceCalculator(new MockAlphabetProvider(), new MockDictionaryProvider());
            return await Task.Run(() => {
                return Ok(DistanceCalculator.CalculateDistance(src, distance));
            });
        }
    }
}