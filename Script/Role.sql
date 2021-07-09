--test
--select CURRENT_USER
-- create ROLE
CREATE ROLE HocVien
CREATE ROLE NVQL_HocVien
CREATE ROLE NVQL_LopHoc
CREATE ROLE ThuNgan
CREATE ROLE Phong_KhaoThi
GO
-- grant priviledges to roles
GRANT SELECT ON HocVien TO HocVien
GRANT SELECT, INSERT, UPDATE, DELETE ON HocVien TO NVQL_HocVien
GRANT SELECT ON LichSuThi TO HocVien
GRANT SELECT ON LichSuTotNghiep TO HocVien
GRANT SELECT ON DangKy TO HocVien, NVQL_LopHoc
GRANT SELECT ON Lop TO HocVien, NVQL_LopHoc
GRANT SELECT ON MonHoc TO HocVien, NVQL_LopHoc
GRANT SELECT ON NhomMonHoc TO HocVien, NVQL_LopHoc
GRANT SELECT ON ChungChi TO HocVien, NVQL_LopHoc
GRANT SELECT ON tbDiem TO HocVien, Phong_KhaoThi

-- EXEC HocVien
GRANT EXEC ON TraCuuDiem_HV TO HocVien
GRANT EXEC ON TraCuuThongTin TO HocVien, NVQL_HocVien
GRANT EXEC ON ChinhSuaThongTin TO HocVien, NVQL_HocVien
GRANT EXEC ON DKHP TO HocVien
GRANT EXEC ON TraCuuLSTN TO HocVien
GRANT EXEC ON TraCuuDSLopMo TO HocVien

GRANT EXEC ON ThemHV TO NVQL_HocVien
GRANT EXEC ON XoaHV TO NVQL_HocVien


GRANT EXEC ON TraCuu TO NVQL_LopHoc
GRANT EXEC ON ThemHP TO NVQL_LopHoc
GRANT EXEC ON XoaHP TO NVQL_LopHoc

GRANT EXEC ON TraCuuDiem TO Phong_KhaoThi
GRANT EXEC ON TraCuuDiemTheoLH TO Phong_KhaoThi






-------------------------HOCVIEN
-- create user
CREATE USER [HV000006] WITH PASSWORD='H881frGF5OZF'
CREATE USER [HV000004] WITH PASSWORD='Ngocvu123'


GO

-- add role to users
ALTER ROLE HocVien ADD MEMBER HV000006
ALTER ROLE HocVien ADD MEMBER HV000004
GO

-------------------------NVQL LOP HOC
-- create user
CREATE USER [QLLH0001] WITH PASSWORD='H2CPk4tIK'
CREATE USER [QLLH0007] WITH PASSWORD='Quanly07'
GO

-- add role to users
ALTER ROLE NVQL_LopHoc ADD MEMBER QLLH0001
ALTER ROLE NVQL_LopHoc ADD MEMBER QLLH0007
GO

-------------------------NVQL HOC VIEN
-- create user
CREATE USER [QLHV0003] WITH PASSWORD='Aloalo123'
GO

-- add role to users
ALTER ROLE NVQL_HocVien ADD MEMBER QLHV0003
GO

----------------------------NVKT
CREATE USER [NVKT0001] WITH PASSWORD='Aloalo123'
GO

-- add role to users
ALTER ROLE Phong_KhaoThi ADD MEMBER NVKT0001
GO