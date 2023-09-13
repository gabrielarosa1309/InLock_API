using Microsoft.EntityFrameworkCore;
using webapi.inlock.db.First.manha.Domains;
using webapi.inlock.dbFirst.manha.Contexts;
using webapi.inlock.dbFirst.manha.Interfaces;

namespace webapi.inlock.dbFirst.manha.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        InlockContext ctx = new InlockContext();
        public void Atualizar(Guid id, Estudio estudio)
        {
            Estudio estudioBuscado = ctx.Estudios.Find(id)!;

            if (estudioBuscado != null) 
            { 
                estudioBuscado.Nome = estudio.Nome;
            }

            ctx.Estudios.Update(estudioBuscado!);

            ctx.SaveChanges();
        }

        public Estudio BuscarPorId(Guid id)
        {
            return ctx.Estudios.FirstOrDefault(z => z.IdEstudio == id);
        }

        public void Cadastrar(Estudio estudio)
        {
            ctx.Estudios.Add(estudio);

            ctx.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Estudio estudioBusacdo = ctx.Estudios.Find(id);

            ctx.Estudios.Remove(estudioBusacdo);

            ctx.SaveChanges();
        }

        public List<Estudio> Listar()
        {
            return ctx.Estudios.ToList();
        }

        public List<Estudio> ListarComJogos()
        {
            return ctx.Estudios.Include(e => e.Jogos).ToList();
        }
    }
}