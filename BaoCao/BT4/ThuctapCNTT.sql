Use  ThucTapCNTT
CREATE TABLE THONGTINTRAODOICUAGIADINH(
id nvarchar(50) PRIMARY KEY,
noidung nvarchar(100),
thoigian datetime,
idnguoidung nvarchar(50)
)

CREATE TABLE THONGTINPHANHOI(
id nvarchar(50) PRIMARY KEY,
noidung nvarchar(100),
thoigian datetime,
idnguoidung nvarchar(50)
)

CREATE TABLE TINTUC(
idtintuc nvarchar(50) PRIMARY KEY,
tieudetintuc nvarchar(100),
ngaythem datetime,
noidung nvarchar(500)
)

CREATE TABLE NGUOIDUNG(
idnguoidung nvarchar(50) PRIMARY KEY,
ten nvarchar(100),
tendangnhap nvarchar(50),
matkhau nvarchar(50),
dienthoai int
)

CREATE TABLE NHOMNGUOIDUNG(
idnhomnguoidung nvarchar(50) PRIMARY KEY,
tennhomnguoidung nvarchar(100),
)

CREATE TABLE QUYEN(
idquyen nvarchar(50) PRIMARY KEY,
tenquyen nvarchar(100),
ghichu nvarchar(50),
)

CREATE TABLE DANHGIAKETQUACHITIET(
idchitiet nvarchar(50) PRIMARY KEY,
ngaydanhgia datetime,
chitiet nvarchar(100)
)

CREATE TABLE DANHGIAKETQUA(
iddanhgia nvarchar(50) PRIMARY KEY,
ketqua nvarchar(100),
)

CREATE TABLE KETQUARENLUYENCHUNG(
idkethochoctap nvarchar(50) PRIMARY KEY,
ketqua nvarchar(100),
ghichu nvarchar(100)
)

CREATE TABLE THOIKHOABIEU(
idtkb nvarchar(50) PRIMARY KEY,
thoigianbatdau time,
thoigianketthuc time,
)

CREATE TABLE BANGDIEM(
idbangdiem nvarchar(50) PRIMARY KEY,
ghichu nvarchar(100),
tongkethocky nvarchar(50)
)

CREATE TABLE CHITIETBANGDIEM(
idchitietbangdiem nvarchar(50) PRIMARY KEY,
diem15phutlan1 float,
diem15phutlan2 float,
diem45phutlan1 float,
diem45phutlan2 float,
diemhocky float
)

CREATE TABLE CHITIETTHOIKHOABIEU(
sotiet int,
thu date,
sothututiet int,
)

CREATE TABLE LOP(
idlop nvarchar(50) PRIMARY KEY,
tenlop nvarchar(100),
)

CREATE TABLE CHITIETLOPHOCSINH(
namhoc nvarchar(50)
)

CREATE TABLE HOCSINH(
idhocsinh nvarchar(50) PRIMARY KEY,
tenhocsinh nvarchar(100),
namsinh date,
dienthoai int,
diachi nvarchar(50)
)

CREATE TABLE HOCKY(
idhocky nvarchar(50) PRIMARY KEY,
tenhocky nvarchar(100),
namhoc nvarchar(50)
)

CREATE TABLE MONHOC(
idmonhoc nvarchar(50) PRIMARY KEY,
tenmonhoc nvarchar(100)
)

CREATE TABLE LICHSUNGHIHOC(
idlichsunghihoc nvarchar(50) PRIMARY KEY,
lydo nvarchar(100),
trangthai nvarchar(50),
cophep bit,
ngaynghi date,
)

CREATE TABLE LICHTHI(
idlichthi nvarchar(50) PRIMARY KEY,
ngaythi date,
giothi time
)

ALTER TABLE DANHGIAKETQUACHITIET ADD iddanhgia nvarchar(50)
ALTER TABLE DANHGIAKETQUACHITIET ADD CONSTRAINT id_danhgia FOREIGN KEY(iddanhgia) REFERENCES DANHGIAKETQUA(iddanhgia)

ALTER TABLE DANHGIAKETQUA ADD idhocsinh nvarchar(50)
ALTER TABLE DANHGIAKETQUA ADD idhocky nvarchar(50)
ALTER TABLE DANHGIAKETQUA ADD CONSTRAINT id_hocsinh2 FOREIGN KEY(idhocsinh) REFERENCES HOCSINH(idhocsinh)
ALTER TABLE DANHGIAKETQUA ADD CONSTRAINT id_hocky2 FOREIGN KEY(idhocky) REFERENCES HOCKY(idhocky)

ALTER TABLE KETQUARENLUYENCHUNG ADD idbangdiem nvarchar(50)
ALTER TABLE KETQUARENLUYENCHUNG ADD iddanhgia nvarchar(50)
ALTER TABLE KETQUARENLUYENCHUNG ADD CONSTRAINT id_bangdiem2 FOREIGN KEY(idbangdiem) REFERENCES BANGDIEM(idbangdiem)
ALTER TABLE KETQUARENLUYENCHUNG ADD CONSTRAINT id_danhgia2 FOREIGN KEY(iddanhgia) REFERENCES DANHGIAKETQUA(iddanhgia)

ALTER TABLE CHITIETTHOIKHOABIEU ADD idtkb nvarchar(50)
ALTER TABLE CHITIETTHOIKHOABIEU ADD idmonhoc nvarchar(50)
ALTER TABLE CHITIETTHOIKHOABIEU ADD CONSTRAINT id_tkb2 FOREIGN KEY(idtkb) REFERENCES THOIKHOABIEU(idtkb)
ALTER TABLE CHITIETTHOIKHOABIEU ADD CONSTRAINT id_monhoc2 FOREIGN KEY(idmonhoc) REFERENCES MONHOC(idmonhoc)


ALTER TABLE CHITIETTHOIKHOABIEU ADD idtkb nvarchar(50) not null
ALTER TABLE CHITIETTHOIKHOABIEU ADD idmonhoc nvarchar(50)
ALTER TABLE CHITIETTHOIKHOABIEU ADD CONSTRAINT id_tkb2 FOREIGN KEY(idtkb) REFERENCES THOIKHOABIEU(idtkb)
ALTER TABLE CHITIETTHOIKHOABIEU ADD CONSTRAINT id_tkb8 PRIMARY KEY(idtkb)
ALTER TABLE CHITIETTHOIKHOABIEU ADD CONSTRAINT id_monhoc2 FOREIGN KEY(idmonhoc) REFERENCES MONHOC(idmonhoc)

ALTER TABLE NGUOIDUNG ADD idnhomnguoidung nvarchar(50)
ALTER TABLE NGUOIDUNG ADD CONSTRAINT id_nguoidung2 FOREIGN KEY(idnhomnguoidung) REFERENCES NHOMNGUOIDUNG(idnhomnguoidung)

ALTER TABLE NHOMNGUOIDUNG ADD idquyen nvarchar(50)
ALTER TABLE NHOMNGUOIDUNG ADD CONSTRAINT id_quyen2 FOREIGN KEY(idquyen) REFERENCES QUYEN(idquyen)

ALTER TABLE BANGDIEM ADD idmonhoc nvarchar(50)
ALTER TABLE BANGDIEM ADD idhocky nvarchar(50)
ALTER TABLE BANGDIEM ADD idhocsinh nvarchar(50)
ALTER TABLE BANGDIEM ADD CONSTRAINT id_monhoc3 FOREIGN KEY(idmonhoc) REFERENCES MONHOC(idmonhoc)
ALTER TABLE BANGDIEM ADD CONSTRAINT id_hocky3 FOREIGN KEY(idhocky) REFERENCES HOCKY(idhocky)
ALTER TABLE BANGDIEM ADD CONSTRAINT id_hocsinh3 FOREIGN KEY(idhocsinh) REFERENCES HOCSINH(idhocsinh)

ALTER TABLE CHITIETBANGDIEM ADD idbangdiem nvarchar(50)
ALTER TABLE CHITIETBANGDIEM ADD CONSTRAINT id_bangdiem3 FOREIGN KEY(idbangdiem) REFERENCES BANGDIEM(idbangdiem)

ALTER TABLE CHITIETLOPHOCSINH ADD idlop nvarchar(50) not null
ALTER TABLE CHITIETLOPHOCSINH ADD idhocsinh nvarchar(50) not null
ALTER TABLE CHITIETLOPHOCSINH ADD CONSTRAINT id_lop8 PRIMARY KEY(idlop,idhocsinh)
ALTER TABLE CHITIETLOPHOCSINH ADD CONSTRAINT id_lop FOREIGN KEY(idlop) REFERENCES LOP(idlop)
ALTER TABLE CHITIETLOPHOCSINH ADD CONSTRAINT id_hocsinh FOREIGN KEY(idhocsinh) REFERENCES HOCSINH(idhocsinh)

ALTER TABLE LICHSUNGHIHOC ADD idhocsinh nvarchar(50)
ALTER TABLE LICHSUNGHIHOC ADD idlop nvarchar(50)
ALTER TABLE LICHSUNGHIHOC ADD CONSTRAINT id_hocsinh4 FOREIGN KEY(idhocsinh) REFERENCES HOCSINH(idhocsinh)
ALTER TABLE LICHSUNGHIHOC ADD CONSTRAINT id_lop2 FOREIGN KEY(idlop) REFERENCES LOP(idlop)

ALTER TABLE LICHTHI ADD idmonhoc nvarchar(50)
ALTER TABLE LICHTHI ADD idhocky nvarchar(50)
ALTER TABLE LICHTHI ADD CONSTRAINT id_monhoc6 FOREIGN KEY(idmonhoc) REFERENCES MONHOC(idmonhoc)
ALTER TABLE LICHTHI ADD CONSTRAINT id_hocky6 FOREIGN KEY(idhocky) REFERENCES HOCKY(idhocky)

