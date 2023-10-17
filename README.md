Nome do Projeto: Construction material cargo transport management (CMCTM)

Descrição do projecto:

O Que é: 

O Sistema de Gestão de Entrega de Materiais de Construção é uma aplicação web que visa facilitar o processo de venda e entrega de materiais de construção, como areia grossa, pedra 3/4 e pedra sarrisca/enrocamento. A empresa trabalha com caminhões de diferentes capacidades, incluindo 7m3, 18m3, 20m3 e 22m3, para atender às necessidades dos clientes. O Sistema de Gestão de Transporte de Material de Construção é uma plataforma que tem como objetivo facilitar a gestão e acompanhamento do transporte de materiais de construção. A aplicação permitirá que os usuários insiram informações sobre os transportes realizados, gerando gráficos e relatórios com base nos dados registrados. Com isso, será possível otimizar o processo de transporte, melhorar a eficiência e tomar decisões estratégicas com base em análises precisas.

O que Faz:

Essa aplicação deverá ser capaz de armazenar de forma abrangente todos os dados relevantes relacionados ao fornecimento de cada entrega de material, incluindo informações sobre o destinatário, o fornecedor e o destino. Além disso, será capaz de criar gráficos informativos e gerar relatórios detalhados para fornecer insights valiosos sobre o desempenho e a eficiência das entregas.

Como Fiz:

Para alcançar as funcionalidades mencionadas na descrição, a aplicação utilizará uma combinação de tecnologias e abordagens de desenvolvimento. Vamos destacar algumas etapas que podem ser adotadas para implementar as características do sistema:
  
  1. Banco de Dados: A aplicação utilizará um banco de dados SQL para armazenar todas as informações relevantes sobre o fornecimento de cada entrega. Serão criadas tabelas para armazenar dados sobre indivíduos, fornecedores, destinos e informações específicas de cada entrega, como a quantidade de material transportado, a data e outras informações pertinentes.
  
  2. Backend: O desenvolvimento do backend será feito utilizando ASP.NET C#. Ele será responsável por processar as requisições do usuário, acessar o banco de dados para ler e gravar informações e realizar a lógica de negócio do sistema. O backend também poderá conter a lógica para criar gráficos informativos e gerar relatórios.

  3. Frontend: A interface do usuário será criada usando HTML, CSS e JavaScript para fornecer uma experiência interativa e responsiva. O frontend permitirá aos usuários visualizar e inserir informações sobre as entregas de materiais, bem como a geração e visualização dos gráficos e relatórios.
  
  4. Gráficos Informativos: A aplicação utilizará bibliotecas de gráficos, como Chart.js ou D3.js, para criar gráficos interativos e informativos. Os dados obtidos do banco de dados serão usados para gerar visualizações gráficas que mostram informações como a quantidade total de material entregue por mês, a distribuição dos fornecedores e outros dados relevantes.
     
  5. Relatórios: A geração de relatórios será feita no backend, utilizando bibliotecas ou frameworks que suportem a criação de documentos em PDF, como o iTextSharp. Os relatórios podem conter informações consolidadas sobre as entregas, fornecedores mais frequentes, desempenho por período e outros dados importantes para a tomada de decisões.
  
  7. Autenticação e Autorização: Para garantir a segurança dos dados e restringir o acesso somente a usuários autorizados, a aplicação implementará um sistema de autenticação e autorização. Isso pode ser realizado usando ASP.NET Identity, que permite gerenciar contas de usuários e permissões.
     
O que usei:

Para desenvolver esse aplicativo usei as seguintes ferramentas 
  1. Linguagem:C#
  2. Framework: Asp.Net Core 6;
  3. Versionamento: Git & GitHub;
  4. DataBase: PostGresql;

Como Usar?

Baixe e instale .net SDK 6;
Baixe e instale VsCode, Visual Studio ou qualquer outra IDE;
