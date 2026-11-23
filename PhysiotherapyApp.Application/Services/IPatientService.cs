using System;
using System.Collections.Generic;
using System.Text;
using PhysiotherapyApp.Application.DTOs;

namespace PhysiotherapyApp.Application.Services
{
    public interface IPatientService
    {
        Task<IEnumerable<PatientRespuestaDto>>
            ObtenerTodosAsync();

        Task<PatientRespuestaDto?>
            ObtenerPorIdAsync(int id);

        Task<PatientRespuestaDto>
            CrearAsync(PatientCrearDto dto);

        Task<bool> ActualizarAsync(
            int id,
           PatientActualizarDto dto);

        Task<bool> EliminarAsync(int id);
    }
}