namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            //Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            if (hospedes.Count > 0 && hospedes.Count <= Suite.Capacidade)
            {
                Hospedes = hospedes;
            }
            else
            {
                var retornoException = hospedes.Count > 0 ?
                    $"Não é possível cadastrar {hospedes.Count} hóspedes, temos apenas {Suite.Capacidade} vagas." :
                    "Cadastre um ou mais hóspedes para fazer uma reserva.";

                //Retornar uma exception caso a capacidade seja menor que o número de hóspedes recebido
                throw new Exception(retornoException);
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
           //Retorna a quantidade de hóspedes (propriedade Hospedes)
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            //Retorna o valor da diária
            decimal valor = Suite.ValorDiaria * DiasReservados;

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            if (DiasReservados > 10)
            {
                valor = valor - (valor*10/100);
            }

            return valor;
        }
    }
}