# ServiceNow AI Insights and Analytics (Incidentes AI)
Uma aplicação Windows Forms que utiliza Inteligência Artificial para analisar, filtrar e visualizar incidentes do ServiceNow em tempo real. O sistema integra o Semantic Kernel para permitir consultas em linguagem natural e o ScottPlot 5 para geração de gráficos dinâmicos.

## Objetivo
O objetivo principal deste projeto é otimizar a análise de grandes volumes de dados operacionais
exportados do ServiceNow.
Muitas vezes, exportar uma planilha de incidentes resulta em centenas de linhas difíceis de interpretar rapidamente.  Este software utiliza IA Generativa para atuar como um "Analista de Dados Virtual",
permitindo que qualque usuário obtenha insights, resumos e gráficos complexos através de simples perguntas, eliminando a necessidade de criar tabelas ou gráficos manuais via Excel.
- Foco em Valor: O tempo do analista é precioso.
- Solução de problema: tabelas dinâmicas manuais são um ponto de dor e a solução oferece uma solução automatizada.

## Funcionalidades
- Processamento de planilhas: Importação e leitura automatizada de arquivos incident.xls gerados na plataforma ServiceNow.
- Assistente de IA Local: Chat interativo que analisa a grade de dados importada. Você pode perguntar: "Analise os incidentes dessa planilha e me mostre os mais críticos".
- Visualização Dinâmica: Geração de gráficos de pizza e barras em janelas independentes, facilitando o dashboarding manual.
- Inteligência de Dados: A IA categoriza e agrupa descrições textuais da planilha que seriam difíceis de filtrar manualmente no Excel.
- Análise de Sentimento: A IA consegue ler as descrições dos chamados e categorizar problemas por similaridade, algo que filtros comuns não fazem.

## Tecnologias Utilizadas
- Linguagem: C# / .NET 8 (WinForms)
- IA: Microsoft Semantic Kernel (Modelos Mistral)
- Gráficos: ScottPlot 5
- Leitura de dados: Integração com bibliotecas de manipulação de Excel/CSV para C#.

## Como Executar o Projeto
### Pré-requisitos
- Visual Studio 2022 ou superior.
- Chave de API (Mistral, OpenAI ou Gemini).
  
### Configuração
1. Clone o repositório
```bash
git clone https://github.com/iribeirodev/IncidentesAI.git
```
2. Crie um arquivo .env a partir do arquivo .env.dev e preencha com suas credenciais.
3. Mude o arquivo .env para ser copiado em cada build.
4. Compile e execute o projeto.
   
## Forma de Uso
1. No ServiceNow, exporte a lista de incidentes como incident.xlsx
2. Em configurações, crie o banco de dados da app.
3. Em configurações utilize o módulo de importação para carregar os dados na grid principal.
4. Na tela principal use os filtros pre-definidos para visualizar melhor os incidentes.
5. Clicando 
6. Faça anotações clicando 2 vezes sobre um dos itens de incidente.
7. Use o chat para solicitar análises:
   "Gere um gráfico de barras para os grupos que aparecem nessa grid."
   "Gere um relatório em Excel dos incidentes criados hoje."
   "Qual o status predominante nos incidentes exportados?"

##  Lógica de Prompt Engineering

Um dos grandes diferenciais deste projeto é a camada de **System Prompting**. A IA não apenas conversa, ela segue um protocolo rigoroso de Analista de Dados Sênior para garantir a integridade das informações.

## Instruções do Sistema (System Prompt)
O comportamento do agente foi moldado com as seguintes diretrizes:

* **Persona:** Especialista em Service Desk focado em relatórios precisos.
* **Protocolo de Dados:** Antes de qualquer análise, a IA é instruída a validar se os dados da grade (`LerDadosDaTabela`) foram carregados, garantindo que ela nunca "invente" informações fora do contexto atual.
* **Tratamento de Exportação:** Regras específicas para a geração de arquivos CSV/Excel, removendo caracteres especiais (como aspas e vírgulas internas) que poderiam corromper a estrutura das colunas.
* **Regras de Negócio (ITIL):** Foco automático em colunas essenciais como `Created` (ordem cronológica), `State`, `Priority` e `AssignmentGroup`.

* Exemplo de lógica aplicada:
```
Você é um analista de dados sênior especializado em Service Desk. Sua missão é analisar incidentes de TI e gerar relatórios precisos.

DIRETRIZES DE FERRAMENTAS:
1. LEITURA DE DADOS: Os dados principais estão no bloco "DADOS DOS TICKETS". 
   - IMPORTANTE: Se o usuário mencionar "o que estou vendo", "esta tela", "esta tabela" ou "dados da grade", você DEVE obrigatoriamente usar a função 'LerDadosDaTabela' para obter os dados em tempo real antes de qualquer análise ou exportação.

2. GERAÇÃO DE EXCEL: Para criar planilhas, use 'CriarExcelComDialogo'. 
   - PARÂMETRO LIMITE: Se o usuário pedir uma quantidade (ex: "top 10", "os 5 últimos"), passe esse número EXATO no campo 'limite'. Se pedir "todos", deixe o limite vazio (null).
   - PARÂMETRO DADOSCSV: Monte um CSV simples. Primeira linha: Cabeçalhos. Linhas seguintes: Dados. 
   - IMPORTANTE: Nunca use aspas (") no CSV. Substitua qualquer vírgula interna dos textos por espaços para não quebrar as colunas.

3. ESTILO DE RESPOSTA:
   - Se a pergunta for "Quantos?", responda apenas o número e uma breve descrição (ex: "Existem 15 chamados com status New").
   - Seja técnico, direto e não invente dados. Se a informação não estiver no contexto nem na tabela da tela, informe que não encontrou.
   - Ao exportar, confirme apenas que a função foi chamada (ex: "Gerando a planilha com os 5 registros solicitados...").

REGRAS DE NEGÓCIO:
- Considere a coluna 'Created' para definir a ordem cronológica (mais recentes primeiro).
- Considere as colunas 'State', 'Priority' e 'AssignmentGroup' para filtros técnicos.
```

## Screenshots
<img width="1427" height="855" alt="image" src="https://github.com/user-attachments/assets/090f362c-281b-4901-9641-d9854f8757b3" />

<img width="691" height="415" alt="image" src="https://github.com/user-attachments/assets/8bed6748-c738-4c38-be66-e93a0f4790d7" />

<img width="598" height="417" alt="image" src="https://github.com/user-attachments/assets/754e3ece-a0ab-4122-8dd2-b64e89323de5" />

<img width="1145" height="723" alt="image" src="https://github.com/user-attachments/assets/971d82d1-9a9c-4d97-8eb7-a157a58ed937" />

## Facilidade de Migração para Azure OpenAI

A arquitetura baseada no **Microsoft Semantic Kernel** permite que a transição para o ambiente 
da companhia seja feita de forma quase instantânea:

- Sem Alteração na Lógica: Não é necessário reescrever as funções de análise, filtros ou 
geração de gráficos. Toda a *inteligência* e os plugins permanecem intactos.
- Troca via Configuração: A migração resume-se a alterar poucas linhas de codigo na inicialização do 
sistema e uso da API Key do Azure.
- Segurança Corporativa: Ao plugar no Azure OpenAI, o projeto passa a herdar automaticamente as camadas
de governança e privacidade de dados da Microsoft, garantindo que as informações dos incidentes não
saim do locatário (tenant) da empresa.