using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Fanap.Plus.Product_Management.Data;
using Fanap.Plus.Product_Management.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fanap.Plus.Product_Management.Models;

namespace Fanap.Plus.Product_Management.Controllers
{
    public class ProductsController : Controller
    {
        private readonly DataContext _context;
        private ITeamDao TeamDao { get; set; }
        private IMemberDao MemberDao { get; set; }
        public ProductsController(DataContext context, ITeamDao teamDao, IMemberDao memberDao)
        {
            _context = context;
            TeamDao = teamDao;
            MemberDao = memberDao;
        }

        // GET: Products
        public async Task<IActionResult> Index(string searchString)
        {
            var products = from p in _context.Products
                select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Name.Contains(searchString));
            }

            return View(await products.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (products == null)
            {
                return NotFound();
            }
            ProductViewModel detailViewModel;
            detailViewModel = new ProductViewModel();
            detailViewModel.Teams = TeamDao.Find(id.Value);
            detailViewModel.DeadlineDate =DateHelper.ConvertToPersian(products.DeadlineDate);
            detailViewModel.CreationDate =DateHelper.ConvertToPersian(products.CreationDate);
            detailViewModel.Description=products.Description;
            detailViewModel.Id=products.Id;
            detailViewModel.Name=products.Name;
            detailViewModel.ProductOwnerName=products.ProductOwnerName;
            detailViewModel.ProductManagementName=products.ProductManagementName;
            detailViewModel.Members = MemberDao.Find(id.Value);
            return View(detailViewModel);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            var createViewModel = new ProductViewModel();
            createViewModel.Teams = _context.Teams.ToList();
            createViewModel.Members = _context.Members.ToList();
            return View(createViewModel);
            
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel viewModel)
        {
            var product = new Products()
            {
                Name = viewModel.Name,
                DeadlineDate = viewModel.GregorianDeadlineDate,
                CreationDate = DateTime.Now,
                Description = viewModel.Description,
                ProductOwnerName = viewModel.ProductOwnerName,
                ProductManagementName = viewModel.ProductManagementName,
            };
            product.TeamAssignments = new List<TeamAssignment>();
            foreach (var team in viewModel.TeamIds)
            {
                product.TeamAssignments.Add(new TeamAssignment()
                {
                    ProductId = product.Id,
                    TeamId = team
                });
            }
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            var pevm = new ProductEditViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                DeadlineDate = DateHelper.ConvertToPersian(product.DeadlineDate),
                ProductOwnerName = product.ProductOwnerName,
                ProductManagementName = product.ProductManagementName,
                Description = product.Description,
                Teams =_context.Teams.ToList(),
                TeamIds = TeamDao.Find(id.Value).Select(t=> t.Id).ToArray(),
                Members = _context.Members.ToList(),
                MemberIds = MemberDao.Find(id.Value).Select(m=> m.Id).ToArray(),
            };
            return View(pevm);
        } 

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,ProductEditViewModel productEdit)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var product = new Products()
                    {
                        Id = productEdit.Id,
                        Name = productEdit.Name,
                        Description = productEdit.Description,
                        DeadlineDate = productEdit.GregorianDeadlineDate,
                        ProductOwnerName = productEdit.ProductOwnerName,
                        ProductManagementName = productEdit.ProductManagementName,
                        TeamAssignments = new List<TeamAssignment>()
                    };
                    foreach (var teamId in productEdit.TeamIds)
                    {
                        product.TeamAssignments.Add(new TeamAssignment()
                        {
                            ProductId = productEdit.Id,
                            TeamId = teamId
                        });
                    }

                    var selectedMembers = _context.Members.Where(m => productEdit.MemberIds.Contains(m.Id) ).ToList();
                    foreach (var member in selectedMembers)
                    {;
                        member.ProductId = productEdit.Id;
                    }
                

                _context.Update(product);
                foreach (var member in productEdit.Members)
                {
                    _context.Update(member);
                }
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductsExists(productEdit.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            return View(productEdit);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var products = await _context.Products.FindAsync(id);
            _context.Products.Remove(products);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductsExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
