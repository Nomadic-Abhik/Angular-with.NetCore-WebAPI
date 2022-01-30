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
                                     departmentType = chapter.DepartmentType,
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
        public IActionResult Post(ResultModel obj)
        {
            try
            {
                ChapterModel model = new ChapterModel();
                model.tittle = obj.tittle;
                model.active = obj.active;
                model.creation_Time = DateTime.Now;
                model.publishedDatetime = obj.publishedDatetime;
                model.DepartmentType = obj.departmentType;
                model.lastmodificationTime = null;
                model.isDeleted = false;
                model.deletionTime = null;
                _context.chapterModels.Add(model);
                _context.SaveChanges();
                int _chapid = model.chapter_Id;
                string[] textSplit = obj.selCategory.Split(",");
                for (int count = 0; count < textSplit.Length; count++)
                {
                    MappingModel mapModel = new MappingModel();
                    mapModel.chapter_Id = _chapid;
                    mapModel.categoryId = Convert.ToInt32(textSplit[count]);
                    mapModel.creationTime = DateTime.Now;
                    mapModel.creatorUserId = 101;//hard coding with random value
                    _context.mappingModels.Add(mapModel);
                    _context.SaveChanges();
                }
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest();
                //Exception Handling Logic
            }
        }
        [HttpPut]
        public IActionResult Put(ResultModel obj)
        {
            try
            {
                var existingEntry = _context.chapterModels.Where(c => c.chapter_Id == obj.chapter_Id).FirstOrDefault();
                if (existingEntry != null)
                {
                    existingEntry.tittle = obj.tittle;
                    existingEntry.creation_Time = existingEntry.creation_Time;
                    existingEntry.publishedDatetime = obj.publishedDatetime;
                    existingEntry.DepartmentType = obj.departmentType;
                    existingEntry.lastmodificationTime = DateTime.Now;
                    if (obj.active == false)
                    {
                        existingEntry.active = false;
                        existingEntry.isDeleted = true;
                        existingEntry.deletionTime = DateTime.Now;
                    }
                    else
                    {
                        existingEntry.active = true;
                        existingEntry.isDeleted = false;
                        existingEntry.deletionTime = null;
                    }

                }
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
                //Exception Handling Logic
            }
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
                return BadRequest();
                //Exception Handling Logic
            }

        }

    }
}
