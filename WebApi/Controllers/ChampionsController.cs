using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Infrastructure.Models;
using WebApi.Infrastructure.Repositories;
using WebApi.Infrastructure.ViewModels;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChampionsController : ControllerBase
    {
        private readonly IRepository<ChampionEntity> repository;
        private readonly IMapper mapper;

        public ChampionsController(IRepository<ChampionEntity> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ChampionViewModel>> GetAll()
        {
            var mappedEntities = mapper.Map<IEnumerable<ChampionViewModel>>(await repository.GetAll());
            return mappedEntities;
        }

        [HttpGet("{id}")]
        public async Task<ChampionViewModel> Get(int id)
        {
            var mappedEntity = mapper.Map<ChampionViewModel>(await repository.Get(id));
            return mappedEntity;
        }

        [HttpPost("add")]
        public int Add([FromBody] ChampionViewModel champion)
        {
            return repository.Add(mapper.Map<ChampionEntity>(champion));
        }

        [HttpPut("update")]
        public int Update([FromBody] ChampionViewModel champion)
        {
            return repository.Update(mapper.Map<ChampionEntity>(champion));
        }

        [HttpDelete("delete/{id}")]
        public bool Delete(int id)
        {
            return repository.Delete(id);
        }

        [HttpPost("upload-image"), DisableRequestSizeLimit]
        public UploadResult Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = "assets";
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
 
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
 
                    using (var stream = new FileStream(fullPath, FileMode.CreateNew))
                    {
                        file.CopyTo(stream);
                    }

                    var filePath = Path.Combine(folderName,fileName);
 
                    return new UploadResult() { Success = true, Path = filePath};
                }
                else
                {
                    return new UploadResult() { Success = false, Path = string.Empty};
                }
            }
            catch (Exception)
            {
                return new UploadResult() { Success = false, Path = string.Empty};
            }
        }

    }
}
