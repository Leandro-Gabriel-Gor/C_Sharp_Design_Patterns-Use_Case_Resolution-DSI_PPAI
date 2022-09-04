using PPAI_DSI.Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace PPAI_DSI
{
    public partial class PantallaReservaTurno : Form
    {
        private Usuario usuario;
        private Login login;
        private Menu menu;

        public GestorReservaTurno gestor;
        private int indexRT = 0;
        private int indexFecha = 0;
        private int indexTurno = 0;
        public InterfazMailReservaTurno intMail = new InterfazMailReservaTurno();
        private List<List<List<string>>> cuboFechas1 = new List<List<List<string>>>();

        // 1. opciónReserva()
        public PantallaReservaTurno(Usuario uss, Login formlogin, Menu men)
        {
            InitializeComponent();
            usuario = uss;
            login = formlogin;
            menu = men;
        }

        // habilitar()
        private void PantallaReservaTurno_Load(object sender, EventArgs e)
        {
            /* ----------- Información de sesion -----------*/

            Sesion sesion = new Sesion(DateTime.Now, DateTime.Now, usuario);


            /* ----------- Caracteristicas -----------*/
            Caracteristica carac = new Caracteristica("Memoria", "cantidad de memoria para guardar");

            Caracteristica carac1 = new Caracteristica("Tamaño", "Tamaño en cm del RT");

            Caracteristica carac2 = new Caracteristica("DPIs", "Cantidad de puntos por pulgada lineal");

            Caracteristica carac3 = new Caracteristica("Colores", "Indica si tiene iluminación RGB");

            Caracteristica carac4 = new Caracteristica("Resolución", "Resolucion en píxeles");

            Caracteristica carac5 = new Caracteristica("Luminancia", "Medida intensidad de luz que emite el monitor.");


            /* ----------- TIPO RECURSO -----------*/

            TipoRecursoTecnologico tipoRT1 = new TipoRecursoTecnologico(
                "Computadora",
                "PC de alta gama - Gigabyte GeForce GTX 1060",
                new List<Caracteristica> { carac });

            TipoRecursoTecnologico tipoRT2 = new TipoRecursoTecnologico(
                "Microscopio",
                "MICROSCOPIO Óptico Compuesto",
                new List<Caracteristica> { carac });

            TipoRecursoTecnologico tipoRT3 = new TipoRecursoTecnologico(
                "Impresora",
                "Impresora doble faz",
                new List<Caracteristica> { carac1 });

            TipoRecursoTecnologico tipoRT4 = new TipoRecursoTecnologico(
                "Mouse",
                "Mouse gamer 1ra generación",
                new List<Caracteristica> { carac2, carac3 });

            TipoRecursoTecnologico tipoRT5 = new TipoRecursoTecnologico(
                "Monitor",
                "Monitor LG Curvo full HD",
                new List<Caracteristica> { carac4, carac5 });


            /* ----------- MODELOS -----------*/

            Modelo modelo1 = new Modelo("LX-500");
            Modelo modelo2 = new Modelo("Dinamic");
            Modelo modelo3 = new Modelo("GT 1050");
            Modelo modelo4 = new Modelo("Y530-150YH");
            Modelo modelo5 = new Modelo("Canopus II");

            /* ----------- MARCAS -----------*/

            Marca marca = new Marca("Sony", new List<Modelo> { modelo1 });
            Marca marca1 = new Marca("Lenovo", new List<Modelo> { modelo2 });
            Marca marca2 = new Marca("Lenovo", new List<Modelo> { modelo3 });
            Marca marca3 = new Marca("LG", new List<Modelo> { modelo4 });
            Marca marca4 = new Marca("Samsung", new List<Modelo> { modelo5 });

            /* ----------- ESTADOS -----------*/
            /* Turno */
            Estado estadoTurno = new Estado(
                "Disponible", "El Turno se encuentra disponible para ser reservado.", "Turno", true, false);
            Estado estadoTurno1 = new Estado(
                "Reserva Pendiente", "La reserva del turno se encuentra pendiente de confirmación.", "Turno", true, false);
            Estado estadoTurno2 = new Estado(
                "Reservado", "El turno ha sido reservado por un personal científico", "Turno", true, false);

            /* RT */

            Estado estadoRT = new Estado(
                "Disponible", "El RT se encuentra disponible para su uso", "RT", true, false);

            Estado estadoRT1 = new Estado(
                "Inicio Mantenimiento", "El RT no se encuentra disponible para su uso", "RT", true, false);


            /* ----------- CAMBIO ESTADO -----------*/
            /* Turno */

            CambioEstadoTurno cambioEstadoTurno = new CambioEstadoTurno(
                DateTime.Parse("13/6/2023 7:43:53"),
                estadoTurno);

            CambioEstadoTurno cambioEstadoTurno1 = new CambioEstadoTurno(
                DateTime.Parse("17/11/2023 19:13:34"),
                estadoTurno);

            CambioEstadoTurno cambioEstadoTurnoReservado = new CambioEstadoTurno(
                DateTime.Parse("17/11/2023 19:13:34"),
                estadoTurno2);



            CambioEstadoTurno cambioEstadoTurno2 = new CambioEstadoTurno(
                DateTime.Parse("18/11/2023 19:13:34"),
                estadoTurno);

            CambioEstadoTurno cambioEstadoTurno3 = new CambioEstadoTurno(
                DateTime.Parse("14/05/2019 20:00:01"),
                estadoTurno1);

            CambioEstadoTurno cambioEstadoTurno4 = new CambioEstadoTurno(
                DateTime.Parse("04/03/2002 11:11:11"),
                estadoTurno2);

            /* RT */

            CambioEstadoRT cambioEstadoRT = new CambioEstadoRT(
                DateTime.Now, estadoRT);

            CambioEstadoRT cambioEstadoRT2 = new CambioEstadoRT(
                DateTime.Parse("19/3/2021 20:04:14"), estadoRT1);

            CambioEstadoRT cambioEstadoRT3 = new CambioEstadoRT(
                DateTime.Parse("15/8/2030 12:03:11"), estadoRT1);

            CambioEstadoRT cambioEstadoRT4 = new CambioEstadoRT(
                DateTime.Parse("19/3/2021 08:09:27"), estadoRT1);

            /* ----------- TURNOS -----------*/

            Turno turno = new Turno(
                DateTime.Now,
                DateTime.Now,
                "viernes",
                DateTime.Now,
                new List<CambioEstadoTurno> { cambioEstadoTurno });

            Turno turno1 = new Turno(
                DateTime.Parse("06/01/2024 6:34:53"),
                DateTime.Parse("06/01/2024 8:37:04"),
                "Miercoles",
                DateTime.Now, new List<CambioEstadoTurno> { cambioEstadoTurno1 }
                );
            Turno turnoReservado1 = new Turno(
                DateTime.Parse("06/01/2024 10:34:53"),
                DateTime.Parse("06/01/2024 12:37:04"),
                "Miercoles",
                DateTime.Now, new List<CambioEstadoTurno> { cambioEstadoTurnoReservado }
                );

            Turno turno2 = new Turno(
                DateTime.Parse("07/01/2024 16:34:53"),
                DateTime.Parse("07/01/2024 18:37:04"),
                "Jueves",
                DateTime.Now, new List<CambioEstadoTurno> { cambioEstadoTurno2 }
                );

            Turno turno3 = new Turno(
                DateTime.Parse("03/12/2024 16:34:53"),
                DateTime.Parse("03/12/2024 8:37:04"),
                "Lunes",
                DateTime.Now, new List<CambioEstadoTurno> { cambioEstadoTurno3 }
                );

            Turno turno4 = new Turno(
                DateTime.Parse("03/12/2024 9:30:53"),
                DateTime.Parse("03/12/2024 9:37:04"),
                "Martes",
                DateTime.Now, new List<CambioEstadoTurno> { cambioEstadoTurno4 }
                );

            Turno turno5 = new Turno(
                DateTime.Parse("03/11/2025 9:30:00"),
                DateTime.Parse("03/11/2025 9:40:00"),
                "Sábado",
                DateTime.Now, new List<CambioEstadoTurno> { cambioEstadoTurno3 }
                );

            Turno turno6 = new Turno(
                DateTime.Parse("08/06/2026 9:30:53"),
                DateTime.Parse("08/06/2026 10:37:00"),
                "Lunes",
                DateTime.Now, new List<CambioEstadoTurno> { cambioEstadoTurno4 }
                );

            Turno turno7 = new Turno(
                DateTime.Parse("03/12/2024 10:30:53"),
                DateTime.Parse("03/12/2024 11:37:04"),
                "Miercoles",
                DateTime.Now, new List<CambioEstadoTurno> { cambioEstadoTurno2 }
                );

            /* ----------- RECURSOS TECNOLOGICOS -----------*/

            RecursoTecnologico recT = new RecursoTecnologico
                (1,
                DateTime.Today,
                "imagen",
                3,
                4,
                tipoRT1,
                new List<Turno> { turno1, turnoReservado1, turno3, turno2 },
                modelo1,
                new List<CambioEstadoRT> { cambioEstadoRT });

            RecursoTecnologico rt = new RecursoTecnologico
                (400,
                DateTime.Parse("6/1/2016 6:34:53"),
                "imagen",
                3,
                4,
                tipoRT1,
                new List<Turno> { turno1, turno2, turno3, turno4, turnoReservado1 },
                modelo2,
                new List<CambioEstadoRT> { cambioEstadoRT }
                );

            RecursoTecnologico rt2 = new RecursoTecnologico
                (300,
                DateTime.Parse("6/1/2016 6:34:53"),
                "imagen",
                13,
                5,
                tipoRT3,
                new List<Turno> { turno2, turno4, turno3, turno7, turnoReservado1 },
                modelo3,
                new List<CambioEstadoRT> { cambioEstadoRT }
                );

            RecursoTecnologico rt3 = new RecursoTecnologico
                (2,
                DateTime.Parse("6/2/2017 14:15:20"),
                "imagen",
                2,
                12,
                tipoRT3,
                new List<Turno> { turno1, turno2, turno3, turno4, turno6, turnoReservado1 },
                modelo3,
                new List<CambioEstadoRT> { cambioEstadoRT, cambioEstadoRT2 }
                );

            RecursoTecnologico rt4 = new RecursoTecnologico
                (3,
                DateTime.Parse("7/3/2018 18:20:00"),
                "imagen",
                7,
                17,
                tipoRT2,
                new List<Turno> { turno, turno3, turno6, turno7, turnoReservado1 },
                modelo3,
                new List<CambioEstadoRT> { cambioEstadoRT }
                );

            RecursoTecnologico rt5 = new RecursoTecnologico
                (300,
                DateTime.Parse("6/1/2016 6:34:53"),
                "imagen",
                13,
                6,
                tipoRT3,
                new List<Turno> { turnoReservado1 },
                modelo3,
                new List<CambioEstadoRT> { cambioEstadoRT2 }
                );

            RecursoTecnologico recT6 = new RecursoTecnologico
                (14,
                DateTime.Today,
                "imagen",
                3,
                4,
                tipoRT4,
                new List<Turno> { turno1, turnoReservado1, turno3, turno2 },
                modelo2,
                new List<CambioEstadoRT> { cambioEstadoRT });

            RecursoTecnologico recT7 = new RecursoTecnologico
                (15,
                DateTime.Today,
                "imagen",
                3,
                4,
                tipoRT5,
                new List<Turno> { turno1, turnoReservado1, turno3, turno2 },
                modelo3,
                new List<CambioEstadoRT> { cambioEstadoRT });

            /* ----------- Personal Cientifico -----------*/

            PersonalCientiico perC1 = new PersonalCientiico(
                "86809", "Mariana", "Shwagger", "34556756", "Inst43@gmail.com", "mariSw1978@gmail.com", "+54 03245678", usuario);

            /* ----------- Asignacion -----------*/
            AsignacionCientificoDelCl asig = new AsignacionCientificoDelCl(
                DateTime.Parse("6/1/2016 6:34:53"),
                perC1,
                new List<Turno> { });

            /* ----------- Centros de Investigacion -----------*/

            CentroDeInvestigacion CI = new CentroDeInvestigacion(
                "Centro de investigacion desarrollo de Sistemas",
                "CIDS",
                "Maestro Lopez 223",
                "Edificio Facha",
                2,
                "32324,123123,213",
                3100,
                "cids@gmail.com",
                3,
                DateTime.Today,
                "reglamento",
                "caracteristica",
                DateTime.Today,
                DateTime.Today,
                "motivo",
                DateTime.Today,
                new List<AsignacionCientificoDelCl> { asig },
                new List<RecursoTecnologico> { rt, rt2, rt3, rt5, recT6 }
                );

            CentroDeInvestigacion CI1 = new CentroDeInvestigacion(
                "Instituto de Antropología de Córdoba",
                "IDACOR ",
                "Av. Hipólito Yrigoyen 174",
                "CONICET-UNC",
                3,
                "32324,123123,213",
                5400,
                "idacor.secretaria@gmail.com",
                2,
                DateTime.Today,
                "reglamento",
                "caracteristica",
                DateTime.Today,
                DateTime.Today,
                "motivo",
                DateTime.Today,
                new List<AsignacionCientificoDelCl> { asig },
                new List<RecursoTecnologico> { recT, rt4, recT7 }
                );

            /* ----------- ASIGNACION Gestor -----------*/

            GestorReservaTurno gestor1 = new GestorReservaTurno
                (
                new List<RecursoTecnologico> { },
                sesion,
                new List<TipoRecursoTecnologico> { },
                DateTime.Now,
                turno,
                true,
                new List<TipoRecursoTecnologico> { },
                /* Datos BD */
                new List<TipoRecursoTecnologico> { tipoRT1, tipoRT2, tipoRT3, tipoRT4, tipoRT5 },
                new List<RecursoTecnologico> { rt, rt2, recT, rt4, rt3, rt5, recT6, recT7 },
                new List<Marca> { marca, marca1, marca2, marca3, marca4 },
                new List<CentroDeInvestigacion> { CI, CI1 },
                new List<PersonalCientiico> { perC1 },
                new List<Estado> { estadoTurno, estadoTurno1, estadoTurno2 }
                );
            gestor = gestor1;
            gestor.nuevaReserva(this);

            /* BOTONES */
            btnSeleccionRecurso.Enabled = false;
            btnSelecFecha.Enabled = false;
            btn_Turno.Enabled = false;
            btnBuscar.Enabled = false;
        }


        // 2. 
        public void pedirSeleccionTipoRT(List<TipoRecursoTecnologico> tiposRT)
        {
            cmbTipoRT.Items.Add("Todos");
            cmbTipoRT.SelectedIndex = -1;
            foreach (TipoRecursoTecnologico tipo in tiposRT)
            {
                cmbTipoRT.Items.Add(tipo.getNombre());
            }
        }

        private void cmbTipoRT_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnBuscar.Enabled = true;
        }

        public void tomarSeleccionTipoRT(object sender, EventArgs e)
        {
            dgvRT.Rows.Clear();
            gestor.tomarSeleccionTipoRT(cmbTipoRT.SelectedIndex, this);
            btnSeleccionRecurso.Enabled = true;
            btnBuscar.Enabled = false;
        }


        // 3. 
        public void pedirSeleccionRT(List<List<string>> mostrarDatos)
        {
            try
            {
                for (int i = 0; i < mostrarDatos.Count; i++)
                {
                    dgvRT.Rows.Add(mostrarDatos[i][0], mostrarDatos[i][1], mostrarDatos[i][2], mostrarDatos[i][3]);
                    switch (mostrarDatos[i][0])
                    {
                        case "Disponible":
                            dgvRT.Rows[i].DefaultCellStyle.BackColor = Color.DodgerBlue;
                            break;
                        case "Mantenimiento":
                            dgvRT.Rows[i].DefaultCellStyle.BackColor = Color.SeaGreen;
                            break;
                        case "Inicio Mantenimiento":
                            dgvRT.Rows[i].DefaultCellStyle.BackColor = Color.Gray;
                            break;
                    }
                }
                switch (mostrarDatos[indexRT][0])
                {
                    case "Disponible":
                        btnSeleccionRecurso.Enabled = true;
                        break;
                    case "Mantenimiento":
                        btnSeleccionRecurso.Enabled = false;
                        break;
                    case "Inicio Mantenimiento":
                        btnSeleccionRecurso.Enabled = false;
                        break;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No hay recursos de ese tipo");
            }
        }

        private void dgvRT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRT = e.RowIndex;
            switch (dgvRT.Rows[indexRT].Cells[0].Value.ToString())
            {
                case "Disponible":
                    btnSeleccionRecurso.Enabled = true;
                    break;
                case "Mantenimiento":
                    btnSeleccionRecurso.Enabled = false;
                    break;
                case "Inicio Mantenimiento":
                    btnSeleccionRecurso.Enabled = false;
                    break;
            }
        }

        private void tomarSeleccionRT(object sender, EventArgs e)
        {
            gestor.tomarSeleccionRT(indexRT, this);
            btnSelecFecha.Enabled = true;
            btnSeleccionRecurso.Enabled = false;
        }


        // 4. Selección dividida en 2 partes. Fecha acá, turno en 5.
        internal void pedirSeleccionDeTurno(List<List<List<string>>> cuboFechas, List<bool> disponibilidadFechas)
        {
            cuboFechas1 = cuboFechas;
            for (int i = 0; i < cuboFechas.Count; i++)
            {
                dgvFechas.Rows.Add(DateTime.Parse(cuboFechas[i][0][1]).Date.ToString("dd/MM/yyyy"));
            }
            for (int i = 0; i < disponibilidadFechas.Count; i++)
            {
                if (disponibilidadFechas[i] == true)
                {
                    dgvFechas.Rows[i].DefaultCellStyle.BackColor = Color.SeaGreen;
                }
                else
                {
                    dgvFechas.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }

        private void dgvFechas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexFecha = e.RowIndex;

            if (dgvFechas.Rows[indexFecha].DefaultCellStyle.BackColor == Color.Red)
            {
                btnSelecFecha.Enabled = false;
            }
            else
            {
                btnSelecFecha.Enabled = true;
            }
        }

        private void tomarSeleccionFecha(object sender, EventArgs e)
        {
            for (int i = 0; i < cuboFechas1[indexFecha].Count; i++)
            {
                dgvTurnos.Rows.Add(cuboFechas1[indexFecha][i][0], DateTime.Parse(cuboFechas1[indexFecha][i][1]).ToString("HH:mm:ss"),
                    DateTime.Parse(cuboFechas1[indexFecha][i][2]).ToString("HH:mm:ss"), cuboFechas1[indexFecha][i][3]);
                switch (cuboFechas1[indexFecha][i][3])
                {
                    case "Disponible":
                        dgvTurnos.Rows[i].DefaultCellStyle.BackColor = Color.DodgerBlue;
                        break;
                    case "Pendiente":
                        dgvTurnos.Rows[i].DefaultCellStyle.BackColor = Color.Gray;
                        break;
                    case "Reservado":
                        dgvTurnos.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                        break;
                }
            }
            btnSelecFecha.Enabled = false;
        }


        // 5. 
        private void dgvTurnos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexTurno = e.RowIndex;
            switch (dgvTurnos.Rows[indexTurno].Cells[3].Value.ToString())
            {
                case "Disponible":
                    btn_Turno.Enabled = true;
                    break;
                case "Reserva Pendiente":
                    btn_Turno.Enabled = false;
                    break;
                case "Reservado":
                    btn_Turno.Enabled = false;
                    break;
            }
        }

        private void tomarSeleccionDeTurno(object sender, EventArgs e)
        {
            gestor.tomarSeleccionTurno(indexTurno, this);
        }


        // 6. 
        internal void pedirConfirmacion()
        {
            DialogResult result = MessageBox.Show("Seguro que desea reservar Turno?", "Confirmar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                tomarConfirmacionReserva();
                cerrarCU();
            }
            else if (result == DialogResult.No)
            {
                cerrarCU();
            }
        }

        private void tomarConfirmacionReserva()
        {
            gestor.tomarConfirmacionReserva(indexTurno, indexFecha, indexRT, this, intMail);
        }

        private void cerrarCU()
        {
            Close();
            menu.Show();
        }


        // 7. Envío de mail
        internal void enviarCorreo(string mensaje, string mail)
        {
            try
            {
                string to = "leandrogabrielgor@gmail.com";
                string from = "lgg.serviceinformatic@gmail.com";
                MailAddress fromEmail = new MailAddress(from);
                MailAddress toEmail = new MailAddress(to);

                MailMessage message = new MailMessage(fromEmail, toEmail);
                message.IsBodyHtml = true;

                message.Subject = "Confirmación turno";
                message.Body = mensaje;

                string smtpServer = "smtp.gmail.com";
                int puerto = 587;

                SmtpClient client = new SmtpClient(smtpServer, puerto);
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(fromEmail.Address, "fmfpimddmrtfsnfq");
                client.Send(message);

                MessageBox.Show("Se ha enviado un mail a: " + to + "\n\n\nMensaje:\n\n" + mensaje, "Reserva de RT Exitosa");
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR\n" + ex);
            }
        }


        // VARIOS
        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            cmbTipoRT.SelectedIndex = -1;
            btnBuscar.Enabled = false;
            dgvRT.Rows.Clear();
            dgvFechas.Rows.Clear();
            dgvTurnos.Rows.Clear();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cerrarCU();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            login.Close();
        }
    }
}