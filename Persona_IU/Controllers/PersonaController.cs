using CrystalDecisions.CrystalReports.Engine;
using Persona_EL;
using Persona_LN;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Persona_IU.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        public ActionResult ListPersona()
        {
            IEnumerable<Persona> lista = null;

            try
            {
                PersonaLN personaLN = new PersonaLN();
                lista = personaLN.GetAllPersona();
            }
            catch (Exception)
            {
                throw;

            }
            return View(lista);
        }
        public ActionResult CreatePersona()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                throw;

            }

        }
        [HttpPost]
        public ActionResult SavePersona(Persona persona)
        {
            try
            {

                PersonaLN personaLN = new PersonaLN();
                personaLN.SavePersona(persona);

            }
            catch (Exception)
            {
                throw;
                //return View("CreatePersona", "Persona");
            }

            return RedirectToAction("ListPersona");

        }
        public ActionResult DeletePersona(string pId)
        {
            try
            {
                PersonaLN personaLN = new PersonaLN();
                var persona = personaLN.GetPersonaById(pId);
                return View(persona);


            }
            catch (Exception)
            {
                throw;
                //return View("CreatePersona", "Persona");
            }



        }
        [HttpPost]
        public ActionResult ConfirmDeletePersona(string pId)
        {
            try
            {
                PersonaLN personaLN = new PersonaLN();
                var persona = personaLN.DeletePersona(pId);
                return RedirectToAction("ListPersona");


            }
            catch (Exception)
            {
                throw;
                //return View("CreatePersona", "Persona");
            }



        }
   
        public ActionResult UpdatePersona(string pId)
        {
            try
            {
                PersonaLN personaLN = new PersonaLN();
                var persona = personaLN.GetPersonaById(pId);
                return View(persona);


            }
            catch (Exception)
            {
                throw;
                //return View("CreatePersona", "Persona");
            }



        }
        public ActionResult DetailPersona(string pId)
        {
            try
            {
                PersonaLN personaLN = new PersonaLN();
                var persona = personaLN.GetPersonaById(pId);
                return View(persona);


            }
            catch (Exception)
            {
                throw;
                //return View("CreatePersona", "Persona");
            }



        }
        public ActionResult ReportPersona()
        {
            List<Persona> lista = new List<Persona>();   
            PersonaLN personaLN = new PersonaLN();
            lista = personaLN.GetAllPersona();
            try
            {
                ReportDocument reportDocument = new ReportDocument();
                reportDocument.Load(Path.Combine(Server.MapPath("~/Reports"), "ReportPersona.rpt"));
                reportDocument.SetDataSource(lista);
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();

                Stream stream = reportDocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                return File(stream,"application/pdf","Personas.pdf");

            }
            catch (Exception ex)
            {
                throw ex;
                
            }



        }
    }
}