
using Common;
using Model.Entities;
using Repository;
using System;
using System.Linq;

namespace Model.BussinesLogic
{
    public class UsuarioLogic
    {
        private ResponseModel rm;
        private Repository<Usuario> repo;

        public UsuarioLogic()
        {
            rm = new ResponseModel();
            repo = new Repository<Usuario>();
            
        }

        public ResponseModel Acceder(string Email, string Password)
        {
          

            try
            {
                using (var ctx = new CmsContext())
                {
                    Password = HashHelper.MD5(Password);

                    var usuario = ctx.Usuario.Where(x => x.Email == Email)
                                             .Where(x => x.Password == Password)
                                             .SingleOrDefault();

                    if (usuario != null)
                    {
                        SessionHelper.AddUserToSession(usuario.idUsuario.ToString());
                        rm.SetResponse(true);
                    }
                    else
                    {
                        rm.SetResponse(false, "Correo o contraseña incorrecta");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return rm;
        }

        public Usuario Obtener(int id)
        {
            try
            {
                using (repo.ContextScope(new CmsContext()))
                {
                    return repo.Get(
                        x => x.idUsuario == id
                  
                    );
                }
            }
            catch (Exception e)
            {


                throw;
            }

           
        }

        public ResponseModel Guardar(Usuario model)
        {
         try
            {
                using (repo.ContextScope(new CmsContext()))
                {
                    if (model.idUsuario == 0) repo.Insert(model);
                    else repo.Update(model);

                    repo.Save();

                    rm.SetResponse(true);
                
                }
            }
            catch (Exception)
            {

                throw;
            }

            return rm;
        }
    }
}
