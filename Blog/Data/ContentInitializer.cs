using Blog.Models;

namespace Blog.Data
{
    public class ContentInitializer
    {
        public static async Task InitializeAsync(ApplicationContext context)
        {
            if (!context.Categories.Any())
            {
                context.Categories.AddRange
                    (
                        new Category { Name = "Путешествия", Description = "Путешествия по всему земному шару." },
                        new Category { Name = "Истории", Description = "Рассказанная история — это прожитая жизнь." },
                        new Category { Name = "Фильмы", Description = "Всё! Кина не будет! Электричество кончилось!" }
                    );
                context.SaveChanges();
            }


            if (!context.Publications.Any())
            {
                context.Publications.AddRange
                    (
                        new Publication
                        {
                            Title = "Детройт: хроники «мёртвого» города",
                            Description = "А вам слабо взять и экспромтом поехать в Детройт, штат Мичиган на автосалон, потому что друзья позвали? Нам оказалось не слабо. Покидали вещички в машину да поехали. И эта поездка неожиданно оказалась эпичной от начала и до конца. А, может, ожидаемо, потому что город всё-таки, видимо, не простой. Уже от многих, кто комментировал мои посты об этой поездке в Фейсбуке, слышала, что там без приключений никак нельзя 🙂 .",
                            Categories = new List<Category>()
                            {
                            context.Categories.FirstOrDefault(e => e.Name.Equals("Путешествия"))
                            },
                            SeoDescription = "Детройт: хроники «мёртвого» города",
                            Keywords = "поездка в детройт"
                        },
                        new Publication
                        {
                            Title = "Достичь успеха, меняя образ",
                            Description = "Когда в городе укрепилось высокое мнение о добродетели и познаниях молодого «священнослужителя», его без возражений избрали папой. Увы, природа, в конце концов, взяла свое и «папа» оказался в интересном положении.",
                            Categories = new List<Category>()
                            {
                            context.Categories.FirstOrDefault(e => e.Name.Equals("Истории")),
                            context.Categories.FirstOrDefault(e => e.Name.Equals("Путешествия"))
                            },
                            SeoDescription = "Достичь успеха, меняя образ. Занимательная история",
                            Keywords = "успех в жизни"
                        }
                    );
                context.SaveChanges();
            }
        }
    }

}
