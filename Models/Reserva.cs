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
            // Verifica se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            if (hospedes.Count <= Suite.Capacidade)
            {
                // Se for, adiciona os hóspedes à lista de hóspedes
                Hospedes = hospedes;
            }
            else
            {
                // retorna uma exceção caso seja tentado cadastrar um maior número de hóspedes do que a capacidade da suite
                throw new Exception ("A capacidade da suite não é suficiente para este número de hóspedes");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // Retorna a quantidade de hospedes
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {

            // Cálculo: DiasReservados X Suite.ValorDiaria
            decimal valor = Suite.ValorDiaria * DiasReservados;

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            if (DiasReservados >= 10)
            {
                valor -= valor * 0.10m;
            }

            return valor;
        }
    }
}