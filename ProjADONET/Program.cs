using Microsoft.Data.SqlClient;
using ProjADONET;

var connection = new SqlConnection(DBConnection.GetConnectionString());



#region Insert

//// Pessoa
//var pessoa = new Pessoa("Pedro", "99999910011", new DateOnly(2000, 09, 09));

//var sqlInsertPessoa = "INSERT INTO Pessoas(nome, cpf, dataNascimento) VALUES (@Nome, @Cpf, @DataNascimento)" + "SELECT SCOPE_IDENTITY();";
//connection.Open();

//var command = new SqlCommand(sqlInsertPessoa, connection);
//command.Parameters.AddWithValue("@Nome", pessoa.Nome);
//command.Parameters.AddWithValue("@Cpf", pessoa.Cpf);
//command.Parameters.AddWithValue("@DataNascimento", pessoa.DataNascimento);


//// Telefone
//int pessoaId = Convert.ToInt32(command.ExecuteScalar());

//var telefone = new Telefone("16", "987815235", "Celular", pessoaId);



//var sqlInsertTelefone = "INSERT INTO Telefones(ddd, numero, tipo, pessoaId) VALUES (@Ddd, @Numero, @Tipo, @PessoaId); ";


//command = new SqlCommand(sqlInsertTelefone, connection);

//command.Parameters.AddWithValue("@Ddd", telefone.Ddd);
//command.Parameters.AddWithValue("@Numero", telefone.Numero);
//command.Parameters.AddWithValue("@Tipo", telefone.Tipo);
//command.Parameters.AddWithValue("@PessoaId", telefone.PessoaId);
//command.ExecuteNonQuery();
//connection.Close();

//// Endereco
//connection.Open();

//var endereco = new Endereco("Rua Pedro II", 700, null, "Centro", "Araraquara", "SP", "14820-200", pessoaId);

//var sqlInsertEndereco = "INSERT INTO Enderecos(logradouro, numero, complemento, bairro, cidade, estado, cep, pessoaId ) " +
//                        "VALUES (@Logradouro, @Numero, @Complemento,@Bairro, @Cidade, @Estado, @Cep, @PessoaId);";
//command = new SqlCommand(sqlInsertEndereco, connection);
//command.Parameters.AddWithValue("@Logradouro", endereco.Logradouro);
//command.Parameters.AddWithValue("@Numero", (object)endereco.Numero ?? DBNull.Value);
//command.Parameters.AddWithValue("@Complemento", (object)endereco.Complemento ?? DBNull.Value);
//command.Parameters.AddWithValue("@Bairro", endereco.Bairro);
//command.Parameters.AddWithValue("@Cidade", endereco.Cidade);
//command.Parameters.AddWithValue("@Estado", endereco.Estado);
//command.Parameters.AddWithValue("@Cep", endereco.Cep);
//command.Parameters.AddWithValue("@PessoaId", endereco.PessoaId);

//command.ExecuteNonQuery();
//connection.Close();

#endregion


#region Select

connection.Open();

var sqlSelectPessoas = "SELECT p.id, p.nome, p.cpf, p.dataNascimento," +
                       "t.id, t.ddd, t.numero, t.tipo, " +
                       "e.id, e.logradouro, e.numero, e.complemento, e.bairro, e.cidade, e.estado, e.cep, e.pessoaId " +
                       "FROM Pessoas p " +
                       "left join Telefones t " +
                        "on p.id = t.pessoaId " +
                        "left join Enderecos e " + 
                        "on p.id = e.pessoaId";

var command = new SqlCommand(sqlSelectPessoas, connection);

var reader = command.ExecuteReader();

List < Pessoa > pessoas= new List<Pessoa>();

while (reader.Read())
{
    
    var pessoaLida = new Pessoa(
        reader.GetString(1),
        reader.GetString(2),
        DateOnly.FromDateTime(reader.GetDateTime(3))
    );
    pessoaLida.setId(reader.GetInt32(0));
    if (!pessoas.Contains(pessoaLida))
    {
        pessoas.Add(pessoaLida);
    }

    Telefone telefoneLido = null;
    if (!reader.IsDBNull(4))
    {
        telefoneLido = new Telefone(
        reader.GetString(5),
        reader.GetString(6),
        reader.GetString(7),
        reader.GetInt32(0)
        );
        telefoneLido.setId(reader.GetInt32(4));
    }
    
    Endereco enderecoLido = null;
    if(!reader.IsDBNull(8))
    {
        enderecoLido = new Endereco(
        reader.GetString(9),
        reader.IsDBNull(10) ? null : reader.GetInt32(10),
        reader.IsDBNull(11) ? null : reader.GetString(11),
        reader.GetString(12),
        reader.GetString(13),
        reader.GetString(14),
        reader.GetString(15),
        reader.GetInt32(16)
        );
        enderecoLido.setId(reader.GetInt32(8));
    }
    
    foreach(var p in pessoas)
    {
        if(p.Id == reader.GetInt32(0))
        {
            if(telefoneLido != null)
            {
                p.Telefones.Add(telefoneLido);
            }
          
            if(enderecoLido != null)
            {
                p.Enderecos.Add(enderecoLido);
            }
            
        }
    }
}

foreach(var pes in pessoas)
{
    Console.WriteLine(pes);
    Console.WriteLine("------");
}

reader.Close();
connection.Close();
#endregion

#region Uptade

//connection.Open();
//var sqlUptadePessoa = "UPDATE Pessoas SET nome = @nome WHERE id = @Id";

//command = new SqlCommand(sqlUptadePessoa, connection);

//command.Parameters.AddWithValue("@Nome", "Felipe Silva");
//command.Parameters.AddWithValue("@Id", 1);

//command.ExecuteNonQuery();

//connection.Close();
#endregion

#region Delete
//connection.Open();
//var sqlDeletePessoa = "DELETE FROM Pessoas WHERE id = @Id";

//command = new SqlCommand(sqlDeletePessoa, connection);

//command.Parameters.AddWithValue("@Id", 6);

//command.ExecuteNonQuery();

//connection.Close();
#endregion