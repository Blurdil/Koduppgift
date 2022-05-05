using Microsoft.VisualStudio.TestTools.UnitTesting;
using Koduppgift.Utilis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koduppgift.Controllers.Api;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Linq;

namespace Koduppgift.Utilis.Tests
{
    [TestClass()]
    public class ApiLoadTests
    {
        [TestMethod()]
        public void GetTopRatedMoviesTest()
        {
            HttpContextAccessor contextAccessor = new HttpContextAccessor();
            var controller = new MostViewedMovies(contextAccessor);

            var response = controller.GetMovies();

            var schema = JsonSchema;
            JSchema jSchema = JSchema.Parse(schema);
            JObject jObject = JObject.Parse(response);
            Assert.IsTrue(jObject.IsValid(jSchema));
            
        }

        public string JsonSchema { get
            {
                return @"{
                    'page': 1,
                    'results': [
                    {
                        'poster_path': 'Imagepath',
                        'adult': false,
                        'overview': 'description',
                        'release_date': 'date',
                        'genre_ids': [
                        14,
                        28,
                        80
                        ],
                        'id': 297761,
                        'original_title': 'title',
                        'original_language': 'en',
                        'title': 'title_org',
                        'backdrop_path': 'backdrop image',
                        'popularity': 48.261451,
                        'vote_count': 1466,
                        'video': false,
                        'vote_average': 5.91
                    }],
                    'dates': {
                    'maximum': '2016-09-01',
                    'minimum': '2016-07-21'
                    },
                    'total_pages': 33,
                    'total_results': 649
                }";
            } 
        }
    }
}