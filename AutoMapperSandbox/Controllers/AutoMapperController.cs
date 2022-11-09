using AutoMapper;
using AutoMapperSandbox.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AutoMapperSandbox.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutoMapperController : ControllerBase
    {
        private readonly IMapper _mapper;

        public AutoMapperController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost]
        [Route("AutoMapPassenger")]
        public ActionResult<PassengerOutput> AutoMapPassenger(PassengerInput passengerInput)
        {
            var mappedResult = _mapper.Map<PassengerOutput>(passengerInput);
            return Ok(mappedResult);
        }

        [HttpPost]
        [Route("AutoMapPassengerList")]
        public ActionResult<IEnumerable<PassengerOutput>> AutoMapPassengerList(IEnumerable<PassengerInput> passengerInput)
        {
            var mappedResult = _mapper.Map<List<PassengerOutput>>(passengerInput);
            return Ok(mappedResult);
        }

        [HttpPost]
        [Route("AutoMapFruit")]
        public ActionResult<FruitOutput> AutoMapFruit(FruitInput fruitInput)
        {
            var mappedResult = _mapper.Map<FruitOutput>(fruitInput);
            return Ok(mappedResult);
        }

        [HttpPost]
        [Route("AutoMapFruitList")]
        public ActionResult<FruitListOutput> AutoMapFruitList(IEnumerable<FruitInput> fruitListInput)
        {
            var mappedResult = _mapper.Map<FruitListOutput>(fruitListInput);
            return Ok(mappedResult);
        }

        [HttpPost]
        [Route("AutoMapBanana")]
        public ActionResult<BananaOutput> AutoMapBanana(FruitInput fruitInput)
        {
            var mappedResult = _mapper.Map<BananaOutput>(fruitInput);
            return Ok(mappedResult);
        }

        [HttpPost]
        [Route("AutoMapContextObject")]
        public ActionResult<FruitListOutput> AutoMapContextObject(ContextObjectInput contextInput, [FromQuery] int daysToAdd )
        {
            var mappedResult = _mapper.Map<ContextObjectOutput>(contextInput, opts => { opts.Items.Add("ExtraDays", daysToAdd); });
            return Ok(mappedResult);
        }

    }
}