using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace DidYouKnow
{

     

    [ApiController]
    [Route("[controller]")]
    public class BalancerController: ControllerBase
    {

        private static readonly string[] Endpoints = {"https://localhost:5035", "https://localhost:5036"};
        private static int counter = 0;

        [HttpGet]
        public async void Balance (string src, double distance){

            counter = (counter+1) % Endpoints.Length;

            string endpoint = Endpoints[counter] + ("/DidYouMean?src="+src+"&distance="+distance);
            Console.Out.WriteLine(endpoint);
            Response.Redirect(endpoint);

        }
    }
}