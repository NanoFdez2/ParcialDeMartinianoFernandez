using ArrayObjeto.Entidades;

namespace ArrayRadio.Datos
{
    public class repositorioDeObjeto
    {
        private readonly string _archivo = Environment.CurrentDirectory + "\\Objeto.txt";
        private readonly string _archivoCopia = Environment.CurrentDirectory + "\\Objeto.bak";
        private List<ArrayObjeto.Entidades.Radio> listaObjetos;

        public repositorioDeObjeto()
        {
            listaObjetos = new List<ArrayObjeto.Entidades.Radio>();
            LeerDatos();
        }
        public List<ArrayObjeto.Entidades.Radio> GetLista()
        {
            return listaObjetos;
        }
        private void LeerDatos()
        {
            if (File.Exists(_archivo))
            {
                var lector = new StreamReader(_archivo);
                while (!lector.EndOfStream)
                {
                    string lineaLeida = lector.ReadLine();
                    ArrayObjeto.Entidades.Radio objeto = ConstruirObjeto(lineaLeida);
                    listaObjetos.Add(objeto);

                }
                lector.Close();
            }
        }
        public void Editar(int objetoAnterior, ArrayObjeto.Entidades.Radio objetoEditar)
        {
            using (var lector = new StreamReader(_archivo))
            {
                using (var escritor = new StreamWriter(_archivoCopia))
                {
                    while (!lector.EndOfStream)
                    {
                        {
                            string lineaLeida = lector.ReadLine();
                            ArrayObjeto.Entidades.Radio objeto = ConstruirObjeto(lineaLeida);
                            if (objetoAnterior != objeto.GetRadio())
                            {
                                escritor.WriteLine(lineaLeida);
                            }
                            else
                            {
                                lineaLeida = ConstruirLinea(objetoEditar);
                                escritor.WriteLine(lineaLeida);
                            }
                        }
                    }
                    File.Delete(_archivo);
                    File.Move(_archivoCopia, _archivo);
                }

            }
        }

        private string ConstruirLinea(ArrayObjeto.Entidades.Radio objeto)
        {
            return $"{objeto.GetRadio()}|{objeto.TipoDeBorde.GetHashCode()}|{objeto.ColorRelleno.GetHashCode()}";
        }
        private ArrayObjeto.Entidades.Radio ConstruirObjeto(string? lineaLeida)
        {
            var campos = lineaLeida.Split('|');
            int lado = int.Parse(campos[0]);
            TipoDeBorde borde = (TipoDeBorde)int.Parse(campos[1]);
            ColorRelleno color = (ColorRelleno)int.Parse(campos[2]);
            Radio c = new Objeto(lado, borde, color);
            return c;
        }

        public void Agregar (ArrayObjeto.Entidades.Radio objeto)
        {
            using (var escritor = new StreamWriter(_archivo, true))
            {
                string lineaEscribir = ConstruirLinea(objeto);
                escritor.WriteLine(lineaEscribir);
                escritor.Close();
            }
            listaObjetos.Add(objeto);
        }
        public int GetCantidad (int? valorFiltro = null)
        {
            if(valorFiltro != null)
            {
                return listaObjetos.Count(c => c.GetRadio() >= valorFiltro);
            }
            return listaObjetos.Count;
        }
        public void Borrar (ArrayObjeto.Entidades.Radio objetoBorrar)
        {
            using (var lector = new StreamReader(_archivo))
            {
                using (var escritor = new StreamWriter(_archivoCopia))
                {
                    while (!lector.EndOfStream)
                    {
                        string lineaLeida = lector.ReadLine();
                        ArrayObjeto.Entidades.Radio objetoLeido = ConstruirObjeto(lineaLeida);
                        if (objetoBorrar.GetRadio() != objetoLeido.GetRadio())
                        {
                            escritor.WriteLine(lineaLeida);
                        }
                    }
                }
            }
            File.Delete(_archivo);
            File.Move(_archivoCopia, _archivo);
            listaObjetos.Remove(objetoBorrar);
        }
        public List<ArrayObjeto.Entidades.Radio> Filtrar(int intValor)
        {
            return listaObjetos.Where(c=>c.GetRadio()>=intValor).ToList();
        }

        public List<ArrayObjeto.Entidades.Radio> OrdenarAsc()
        {
            return listaObjetos.OrderBy(c=>c.GetRadio()).ToList();
        }

        public List<ArrayObjeto.Entidades.Radio> OrdenarDesc()
        {
            return listaObjetos.OrderByDescending(c => c.GetRadio()).ToList();
        }
    }
}