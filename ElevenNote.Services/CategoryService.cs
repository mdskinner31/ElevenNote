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

                using (var ctx = new ApplicationDbContext())
                {
                    ctx.Category.Add(centity);
                    return ctx.SaveChanges() == 1;
                }
            }

            public IEnumerable<NoteListItem> GetCategory()
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var query =
                        ctx
                            .Notes
                            .Where(e => e.OwnerId == _userId)
                            .Select(
                                e =>
                                    new NoteListItem
                                    {
                                        NoteId = e.NoteId,
                                        Title = e.Title,
                                        CategoryId = e.CategoryId,
                                        CreatedUtc = e.CreatedUtc
                                    }
                            );

                    return query.ToArray();
                }
            }

            public NoteDetail GetNoteByCategoryId(int categoryId)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Notes
                            .Single(e => e.NoteId == categoryId && e.OwnerId == _userId);
                    return
                        new NoteDetail
                        {
                            NoteId = entity.NoteId,
                            Title = entity.Title,
                            Content = entity.Content,
                            CategoryId = entity.CategoryId,
                            CreatedUtc = entity.CreatedUtc,
                            ModifiedUtc = entity.ModifiedUtc
                        };
                }
            }

            public bool UpdateCategory(CategoryEdit cmodel)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Notes
                            .Single(e => e.CategoryId == cmodel.CategoryId && e.OwnerId == _userId);

                   // entity.Title = cmodel.Title;
                   // entity.Content = cmodel.Content;
                    entity.CategoryId = cmodel.CategoryId;
                    entity.ModifiedUtc = DateTimeOffset.UtcNow;

                    return ctx.SaveChanges() == 1;
                }
            }

            public bool DeleteCategory(int categoryId)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Notes
                            .Single(e => e.CategoryId == categoryId && e.OwnerId == _userId);

                    ctx.Notes.Remove(entity);

                    return ctx.SaveChanges() == 1;
                }
            }
        
    }
}
