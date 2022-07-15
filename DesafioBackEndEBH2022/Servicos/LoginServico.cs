using DesafioBackEndEBH2022.Models;

namespace DesafioBackEndEBH2022.Servicos
{
    public class LoginServico
    {
        public async Task<LoginRespostaModel> Login(LoginRequisicaoModel loginRequisicaoModel)
        {
            LoginRespostaModel loginRespostaModel = new LoginRespostaModel();
            loginRespostaModel.Autenticado = false;
            loginRespostaModel.Usuario = loginRequisicaoModel.Usuario;
            loginRespostaModel.Token = "";
            loginRespostaModel.DataExpiracao = null;

            if (loginRequisicaoModel.Usuario == "Usuario123" && loginRequisicaoModel.Senha == "Senha123")
            {
                loginRespostaModel = new GeradorToken().GerarToken(loginRespostaModel);
            }

            return loginRespostaModel;
        }
    }
}
