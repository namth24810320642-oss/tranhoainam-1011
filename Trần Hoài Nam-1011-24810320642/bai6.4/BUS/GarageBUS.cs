using System.Collections.Generic;
using System.Data;
using GarageManagement.DAL;
using GarageManagement.DTO;

namespace GarageManagement.BUS
{
    public class GarageBUS
    {
        private GarageDAL garageDAL = new GarageDAL();

        public DataRow LookupCar(string bienSo)
        {
            return garageDAL.GetCarByBienSo(bienSo);
        }

        public bool RegisterCarAndOwner(KhachHangDTO kh, XeDTO xe)
        {
            return garageDAL.AddCustomerAndCar(kh, xe);
        }

        public DataTable GetParts()
        {
            return garageDAL.GetAllParts();
        }

        public bool EditPart(PhuTungDTO pt)
        {
            return garageDAL.UpdatePart(pt);
        }

        public bool SaveRepairTicket(PhieuSuaChuaDTO ticket, List<ChiTietSuaChuaDTO> details)
        {
            decimal totalCost = 0;
            foreach (var item in details)
            {
                totalCost += (item.SoLuong * item.DonGia) + item.TienCong;
            }
            ticket.TongTien = totalCost;

            return garageDAL.CreateRepairTicketTransaction(ticket, details);
        }

        public DataTable GetPendingPaymentTickets()
        {
            return garageDAL.GetUnpaidTickets();
        }

        public bool PayTicket(int maPhieu)
        {
            return garageDAL.CheckoutTicket(maPhieu);
        }
    }
}