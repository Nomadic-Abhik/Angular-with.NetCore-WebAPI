using Assignment.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChapterController : ControllerBase
    {
        private readonly DALDbContext _context; 
        public ChapterController(DALDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IEnumerable<ResultModel> GetData()
        {
            try
            {
                var mappingList = (from item in _context.categoryModels
                                   join map in _context.mappingModels
                                   on item.category_Id equals map.categoryId
                                   select new
                                   {
                                       Id = item.category_Id,
                                       name = item.tittle,
                                       chap = map.chapter_Id
                                   });
                var resulList = (from chapter in _context.chapterModels
                                 where chapter.isDeleted == false
                                 select new ResultModel()
                                 {
                                     chapter_Id = chapter.chapter_Id,
                                     tittle = chapter.tittle,
                                     active = chapter.active,
                                     DepartmentType = chapter.DepartmentType,
                                     publishedDatetime = chapter.publishedDatetime,
                                     selectedCategory = mappingList.Where(c => c.chap == chapter.chapter_Id).Select(store => new CategoryModel { category_Id = store.Id, tittle = store.name }).ToList()
                                 });
                return resulList.ToList();
            }
            catch(Exception ex)
            {
                return null;
                //Exception Handling Logic- may b DB Log,I am returning null as of now
            }
            
        }
        [HttpGet]
        [Route("/api/chapter/getStaticData")]
        public IEnumerable<CategoryModel> GetData(bool staticData = true)
        {
            try
            {
                var categoryList = (from item in _context.categoryModels
                                    where item.isDeleted == false
                                    select new CategoryModel()
                                    {
                                        category_Id = item.category_Id,
                                        tittle = item.tittle,
                                    });

                return categoryList.ToList();
            }
            catch (Exception ex)
            {
                return null;
                //Exception Handling Logic- may b DB Log,I am returning null as of now
            }

        }

        [HttpPost]
        [Route("/api/chapter/PostChapter")]
        public IActionResult Post(ResultModel obj)
        {
            var data = _context.chapterModels.ToList();
            _context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Put([FromBody] ChapterModel obj)
        {
            var data = _context.chapterModels.Update(obj);
            return Ok();
        }

        [HttpDelete]
        public  IActionResult Delete([FromQuery] int id)
        {
            try
            {
                var data = _context.chapterModels.Where(a => a.chapter_Id == id).FirstOrDefault();
                data.isDeleted = true;
                data.lastmodificationTime = DateTime.Now;
                data.deletionTime = DateTime.Now;
                _context.SaveChanges();
                return Ok();
            }
            catch(Exception ex)
            {
                return null;
                //Exception Handling Logic- may b DB Log,I am returning null as of now
            }

        }

    }
}
