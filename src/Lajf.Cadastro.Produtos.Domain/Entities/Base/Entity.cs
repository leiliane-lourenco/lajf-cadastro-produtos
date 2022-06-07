using System;
using System.Collections.Generic;
using System.Text;

namespace Lajf.Cadastro.Produtos.Domain.Entities.Base
{
    public class Entity
    {
        public Guid Id { get; set; }


        public Entity()
        {
            Id = Guid.NewGuid();
     
        }


    }
}
