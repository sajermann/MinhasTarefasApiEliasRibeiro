using MinhasTarefasApiEliasRibeiro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhasTarefasApiEliasRibeiro.Repositories.Contracts
{
    interface IUsuarioRepository
    {
        void Cadastrar(ApplicationUser usuario, string senha);
       Task<ApplicationUser> Obter(string email, string senha);
    }
}
