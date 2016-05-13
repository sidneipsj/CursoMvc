using System;
using System.Net;
using System.Web.Mvc;
using GL.CursoMvc.Application;
using GL.CursoMvc.Application.ViewModel;

namespace GL.CursoMvc.UI.Mvc.Controllers
{
    [RoutePrefix("administracao")]
    public class ClientesController : Controller
    {
        private readonly ClienteAppService _clienteAppService;

        public ClientesController()
        {
            _clienteAppService = new ClienteAppService();
        }

        // GET: Clientes
        [Route("listar-clientes")]
        public ActionResult Index()
        {
            return View(_clienteAppService.ObterTodos());
        }

        // GET: Clientes/Details/5
        [Route("{id:guid}/visualizar-cliente")]
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var clienteViewModel = _clienteAppService.ObterPorId(id.Value);

            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }

            return View(clienteViewModel);
        }

        // GET: Clientes/Create
        [Route("novo-cliente")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        [Route("novo-cliente")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            if (ModelState.IsValid)
            {
                _clienteAppService.Adicionar(clienteEnderecoViewModel);
                return RedirectToAction("Index");
            }

            return View(clienteEnderecoViewModel);
        }

        // GET: Clientes/Edit/5
        [Route("{id:guid/editar-cliente}")]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var clienteViewModel = _clienteAppService.ObterPorId(id.Value);

            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }

            return View(clienteViewModel);
        }

        // POST: Clientes/Edit/5
        [Route("{id:guid/editar-cliente}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                _clienteAppService.Atualizar(clienteViewModel);
                return RedirectToAction("Index");
            }

            return View(clienteViewModel);
        }

        // GET: Clientes/Delete/5
        [Route("{id:guid}/excluir-cliente")]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var clienteViewModel = _clienteAppService.ObterPorId(id.Value);

            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }

            return View(clienteViewModel);
        }

        // POST: Clientes/Delete/5
        [Route("{id:guid}/excluir-cliente")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _clienteAppService.Remover(id);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _clienteAppService.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
