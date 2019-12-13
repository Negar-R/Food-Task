using System;
using Food.Data;
using Food.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FoodTest()
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var recepyId = GetRecepyId();
                    Recipe recipee = session.Get<Recipe>(recepyId);

                    Foodd food = new Foodd()
                    {
                        Name = "Spageti" ,
                        Price = 20
                    };

                    food.Recepies.Add(recipee);

                    session.Save(food);
                    transaction.Commit();

                    var res = session.Get<Foodd>(food.Id);
                    Assert.AreEqual(res.Name, "Spageti");
                }
            }
        }
        [TestMethod]
        public void RecepyTest()
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var recipeId = GetRecepyId();
                    Recipe recipe = session.Get<Recipe>(recipeId);

                    session.Save(recipe);
                    transaction.Commit();

                    var res = session.Get<Recipe>(recipe.Id);
                    Assert.AreEqual(recipe.Name, "Meet");
                }
            }
        }
        private Guid GetRecepyId()
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    Recipe recipe = new Recipe()
                    {
                        Name = "Meet",
                        Unit = Unit.Gram
                    };

                    session.Save(recipe);
                    transaction.Commit();

                    recipe = session.Get<Recipe>(recipe.Id);
                    return recipe.Id;
                }
            }
        }
    }
}
