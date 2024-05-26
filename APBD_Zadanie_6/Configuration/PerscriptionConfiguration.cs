using APBD_Zadanie_6.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBD_Zadanie_6.Configuration
{
	public class PrescriptionConfig : IEntityTypeConfiguration<Prescription>
	{
		public void Configure(EntityTypeBuilder<Prescription> builder)
		{
			builder.HasKey(p => p.IdPrescription)
				.HasName("Prescription_PK");  

			builder.ToTable("Prescription");

			builder.Property(p => p.Date)
				.IsRequired();  

			builder.Property(p => p.DueDate)
				.IsRequired();  

			builder.HasOne(p => p.DoctorNav)
				.WithMany(d => d.Prescriptions)
				.HasForeignKey(p => p.IdDoctor)
				.OnDelete(DeleteBehavior.ClientSetNull)  
				.HasConstraintName("Prescription_Doctor_FK");

			builder.HasOne(p => p.PatientNav)
				.WithMany(pa => pa.Prescriptions)
				.HasForeignKey(p => p.IdPatient)
				.OnDelete(DeleteBehavior.ClientSetNull)  
				.HasConstraintName("Prescription_Patient_FK");

			builder.HasData(new Prescription
			{
				IdPrescription = 1,
				Date = new DateTime(2022, 01, 01),
				DueDate = new DateTime(2022, 06, 01),
				IdDoctor = 1,
				IdPatient = 1
			},
			new Prescription
			{
				IdPrescription = 2,
				Date = new DateTime(2022, 02, 15),
				DueDate = new DateTime(2022, 08, 15),
				IdDoctor = 2,
				IdPatient = 2
			});
		}
	}
}
