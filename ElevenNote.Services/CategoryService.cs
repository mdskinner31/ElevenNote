using ElevenNote.Data;
using ElevneNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Services
{
    public class CategoryService
    {

        private readonly Guid _userId;

        public CategoryService(Guid userId)
        {
            _userId = userId;
        }


        public bool CreateCategory(CategoryCreate cmodel)
        {
            var centity =
                new Category()
                {

                     CategoryId = cmodel.CategoryId,
                    CategoryName = cmodel.CategoryName

                };

            using (var cctx = new ApplicationDbContext())
            {
                cctx.Category.Add(centity);
                return cctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CategoryListItem> GetCategory()
        {
            using (var cctx = new ApplicationDbContext())
            {
                var query =
                    cctx    
                     // .Notes
                       .Category
                        .Where(e => e.CategoryId == e.CategoryId)
                        .Select(
                            e =>
                                new CategoryListItem
                                {
                                        //NoteId = e.NoteId,
                                        // Title = e.Title,
                                        CategoryId = e.CategoryId,
                                        CategoryName = e.CategoryName,
                                        // CreatedUtc = e.CreatedUtc
                                    }
                        );

                return query.ToArray();
            }
        }

        public CategoryDetail GetCategoryById(int categoryId)
        {
            using (var cctx = new ApplicationDbContext())
            {
                var centity =
                    cctx
                        // .Notes
                        .Category
                        .Single
                        (e => e.CategoryId == categoryId);
                       // && e.NoteId == id);
                return
                    new CategoryDetail
                    {
                       // NoteId = centity.NoteId,
                       // Title = centity.Title,
                       // Content = centity.Content,
                        CategoryId = centity.CategoryId,
                        CategoryName = centity.CategoryName,
                      //  CreatedUtc = centity.CreatedUtc,
                        // ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public bool UpdateCategory(CategoryEdit cmodel)
        {
            using (var cctx = new ApplicationDbContext())
            {
                var centity =
                    cctx
                       // .Notes
                       .Category
                        .Single(e => e.CategoryId == cmodel.CategoryId);
                        //&& e.OwnerId == CategoryId);

                // entity.Title = cmodel.Title;
                // entity.Content = cmodel.Content;
                centity.CategoryId = cmodel.CategoryId;
                centity.CategoryName = cmodel.CategoryName;
                //centity.ModifiedUtc = DateTimeOffset.UtcNow;

                return cctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCategory(int categoryId)
        {
            using (var cctx = new ApplicationDbContext())
            {
                var centity =
                    cctx
                        // .Notes
                        .Category
                        .Single(e => e.CategoryId == categoryId); //&& e.OwnerId == CategoryId);

                cctx.Category.Remove(centity);

                return cctx.SaveChanges() == 1;
            }


        }

    }
}
