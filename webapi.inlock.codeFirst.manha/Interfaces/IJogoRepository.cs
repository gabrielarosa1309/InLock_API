﻿using webApi.inlock.codeFirst.manha.Domains;

namespace webApi.inlock.codeFirst.manha.Interfaces
{
    public interface IJogoRepository
    {
        List<Jogo> Listar();

        Jogo BuscarPorId(Guid id);

        void Cadastrar(Jogo novoJogo);

        void Atualizar(Guid id, Jogo jogo);

        void Deletar(Guid id);
    }
}
