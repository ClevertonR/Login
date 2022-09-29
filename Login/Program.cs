



public void Logar()
{


    string con = " server = DESKTOP-6BAVUH0; Database = Cadastro; Trusted_Connection = true";
    SqlConnection Conex = new SqlConnection(con);

    string coman = @"SELECT Count (*) FROM usuario WHERE Login = @nome AND Senha = @password AND [E-mail] = @email";

    string nome = textBox1.Text, password = textBox2.Text, email = textBox3.Text;
    try

    {


        SqlCommand comando = new SqlCommand(coman, Conex);

        comando.Parameters.AddWithValue("@nome", nome);
        comando.Parameters.AddWithValue("@password", password);
        comando.Parameters.AddWithValue("@email", email);
        Conex.Open();

        int valor = (int)comando.ExecuteScalar();
        if (valor > 0)
        {
            Logado = true;
            MessageBox.Show("Logado com sucesso. Sejam bem-vindo!");

            this.Close();
        }
        else
        {
            Logado = false;
            MessageBox.Show("Dados incorretos!");

        }
    }

    catch (SqlException erro)

    {

        MessageBox.Show(erro + "Na conexão com o banco de dados");
    }

    finally
    {
        Conex.Close();


    }

}