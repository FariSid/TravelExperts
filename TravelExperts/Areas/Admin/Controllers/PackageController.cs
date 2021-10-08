using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelExperts.Models;

namespace TravelExperts.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class PackageController : Controller
    {

        private TravelExpertsUnitOfWork data { get; set; }
        public PackageController(TravelExpertsContext ctx) => data = new TravelExpertsUnitOfWork(ctx);

        //private IRepository<Package> data;
        //public PackageController(IRepository<Package> rep)
        //{
        //    data = rep;
        //}

        // GET: PackageController
        public ActionResult Index()
        {
            //var search = new SearchData(TempData);
            //search.Clear();

            //return View();
            var q = new QueryOptions<Package>();
            q.OrderBy = s => s.PackageId;

            var packages = data.Packages.List(q);
            return View("List", packages);
            //var authors = data.Packages.List(new QueryOptions<Package>
            //{
            //    OrderBy = a => a.PkgName
            //});
            //return View(authors);

            //var q = new QueryOptions<PackageViewModel>();
            //q.OrderBy = s => s.Package.PkgName;
            ////q.Include = "StudentGrade";
            ////q.Where = s => s.StudentGrade.GradeLevel == "3"; 

            //var packages = PackageViewModel.List(q);
            //return View(packages);
        }
        //[Authorize (Roles = "Customer")]
        // GET: PackageController/Details/5

        [HttpPost]
        public RedirectToActionResult Search(SearchViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var search = new SearchData(TempData)
                {
                    SearchTerm = vm.SearchTerm,
                    Type = vm.Type
                };
                return RedirectToAction("Search");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }


        [HttpGet]
        public ViewResult Search()
        {
            var search = new SearchData(TempData);

            if (search.HasSearchTerm)
            {
                var vm = new SearchViewModel
                {
                    SearchTerm = search.SearchTerm
                };

                var options = new QueryOptions<Package>
                {
                    Include = "Package.Desc"
                };
                if (search.IsPackage)
                {
                    options.Where = b => b.PkgName.Contains(vm.SearchTerm);
                    vm.Header = $"Search results for Package Name '{vm.SearchTerm}'";
                }
                if (search.IsDescription)
                {
                    //int index = vm.SearchTerm.LastIndexOf(' ');
                    //if (index == -1)
                    //{
                        options.Where = b => b.PkgDesc.Contains(vm.SearchTerm);
                            // ba => ba.Author.FirstName.Contains(vm.SearchTerm) ||
                            vm.Header = $"Search results for Package Description '{vm.SearchTerm}'";
                    //}
                    //else
                    //{
                    //    string first = vm.SearchTerm.Substring(0, index);
                    //    string last = vm.SearchTerm.Substring(index + 1);
                    //    options.Where = b => b.PkgDesc.Contains();
                    //}
                    //vm.Header = $"Search results for author '{vm.SearchTerm}'";
                }
                //if (search.IsGenre)
                //{
                //    options.Where = b => b.GenreId.Contains(vm.SearchTerm);
                //    vm.Header = $"Search results for genre ID '{vm.SearchTerm}'";
                //}
                vm.Packages = data.Packages.List(options);
                return View("SearchResults", vm);
            }
            else
            {
                return View("Index");
            }
        }







        [HttpGet]
        public ViewResult Add(int id) => GetPackage(id, "Add");

        [HttpPost]
        public IActionResult Add(PackageViewModel vm)
        {
            if (ModelState.IsValid)
            {
                //data.LoadNewBookAuthors(vm.Book, vm.SelectedAuthors);
                data.Packages.Insert(vm.Package);
                data.Save();

                TempData["message"] = $"{vm.Package.PkgName} added to Packages.";
                return RedirectToAction("Index");
            }
            else
            {
                Load(vm, "Add");
                return View("Package", vm);
            }
        }

        [HttpGet]
        public ViewResult Edit(int id) => GetPackage(id, "Edit");

        [HttpPost]
        public IActionResult Edit(PackageViewModel vm)
        {
            if (ModelState.IsValid)
            {
                //data.DeleteCurrentBookAuthors(vm.Book);
                //data.LoadNewBookAuthors(vm.Book, vm.SelectedAuthors);
                data.Packages.Update(vm.Package);
                data.Save();

                TempData["message"] = $"{vm.Package.PkgName} updated.";
                return RedirectToAction("Index");
            }
            else
            {
                Load(vm, "Edit");
                return View("Package", vm);
            }
        }

        [HttpGet]
        public ViewResult Delete(int id) => GetPackage(id, "Delete");

        [HttpPost]
        public IActionResult Delete(PackageViewModel vm)
        {
            data.Packages.Delete(vm.Package);
            data.Save();
            TempData["message"] = $"{vm.Package.PkgName} removed from Packages.";
            return RedirectToAction("Index");
        }

        private ViewResult GetPackage(int id, string operation)
        {
            var Package = new PackageViewModel();
            Load(Package, operation, id);
            return View("Package", Package);
        }
        private void Load(PackageViewModel vm, string op, int? id = null)
        {
            if (Operation.IsAdd(op))
            {
                vm.Package = new Package();
            }
            else
            {
                vm.Package = data.Packages.Get(new QueryOptions<Package>
                {
                    //Include = "BookAuthors.Author, Genre",
                    Where = b => b.PackageId == (id ?? vm.Package.PackageId)
                });
            }

            //vm.SelectedProducts = vm.Package.PackagesProductsSuppliers?.Select(
            //    ba => ba.Author.AuthorId).ToArray();
            vm.Products = data.Products.List(new QueryOptions<Product>
            {
                OrderBy = a => a.ProdName
            });
            //vm.Genres = data.Genres.List(new QueryOptions<Genre>
            //{
            //    OrderBy = g => g.Name
            //});
        }

    }
}