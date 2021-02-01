using System;

namespace Exam70483Web.Models.Entity
{
    //
    public class MusicTrack
    {
        public int ID        { get; set; }
        public string Artist { get; set; }
        public string Title  { get; set; }
        public int Length    { get; set; }
    }
    //
    public class PersonaEntity
    {
        public string ID              { get; set; }
        public string NombreCompleto  { get; set; }
        public string ProfesionOficio { get; set; }
    }
    //
    public class AccessLogEntity
    {
        public int Id_Column       { get; set; }
        public String PageName     { get; set; }
        public DateTime AccessDate { get; set; }
        public String IPValue      { get; set; }
    }
}