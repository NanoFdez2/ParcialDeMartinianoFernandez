using ArrayRadio.Entidades;

namespace ArrayObjeto.Entidades
{
    public class Esfera
    {
        public Esfera(int radio, TipoDeBorde borde, ColorRelleno color)
        {
            _medidaRadio = radio;
            tipodeBorde = borde;
            colorRelleno = color;
        }
        private int _medidaRadio;
        public int GetRadio() => _medidaRadio;
        public void SetRadio(int radio)
        {
            if (radio > 0)
            {
                _medidaRadio = radio;
            }
        }
        public Esfera()
        {

        }
        private ColorRelleno colorRelleno;
        public ColorRelleno ColorRelleno
        {
            get { return colorRelleno; }
            set { colorRelleno = value; }
        }
        private TipoDeBorde tipodeBorde;
        public TipoDeBorde TipoDeBorde
        {
            get { return tipodeBorde; }
            set { tipodeBorde = value; }
        }

        public double GetVolumen() => Math.PI/(4/3) * Math.Pow(_medidaRadio, 3);
        public double GetArea() => 4*Math.PI*Math.Pow(_medidaRadio, 2);

    }
}