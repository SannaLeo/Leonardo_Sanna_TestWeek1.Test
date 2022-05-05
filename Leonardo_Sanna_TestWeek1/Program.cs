
using Leonardo_Sanna_TestWeek1;
using Leonardo_Sanna_TestWeek1.Entities;
using Leonardo_Sanna_TestWeek1.Interfaces;
using Leonardo_Sanna_TestWeek1.Repository;

IRepository<ProdottoAlimentare> repopa = new RepositoryProdottiAlimentariFile();
GestioneNegozio.Start();
Task<List<ProdottoAlimentare>> prodottiTask = repopa.GetAllAsync();
var prodotti = await prodottiTask;
