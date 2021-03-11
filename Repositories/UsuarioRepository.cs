using Microsoft.AspNetCore.Identity;
using MinhasTarefasApiEliasRibeiro.Models;
using MinhasTarefasApiEliasRibeiro.Repositories.Contracts;
using System;
using System.Text;
using System.Threading.Tasks;

namespace MinhasTarefasApiEliasRibeiro.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public UsuarioRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        async public Task<ApplicationUser> Obter(string email, string senha)
        {
            var usuario = await _userManager.FindByEmailAsync(email);
            if (await _userManager.CheckPasswordAsync(usuario, senha))
            {
                return usuario;
            }
            else
            {
                /*
                 Domain Notification
                 */
                throw new Exception("Usuário não localizado");
            }
        }
        
        async public void Cadastrar(ApplicationUser usuario, string senha)
        {
            var result = await _userManager.CreateAsync(usuario, senha);
            if (!result.Succeeded)
            {
                StringBuilder sb = new StringBuilder();
                foreach(var erro in result.Errors){
                    sb.Append(erro.Description);
                }
                /*
                Domain Notification
                */
                throw new Exception($"Usuário não cadastrado! {sb.ToString()} ");
            }
        }
    }
}
