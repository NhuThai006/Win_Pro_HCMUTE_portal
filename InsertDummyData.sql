USE QuanLySinhVien;
GO

-- ==========================================================
-- 1. ALTER TABLE ĐỂ THÊM RÀNG BUỘC (CONSTRAINTS) CHẶT CHẼ
-- ==========================================================
IF OBJECT_ID('FK_Student_Login', 'F') IS NULL ALTER TABLE Student ADD CONSTRAINT FK_Student_Login FOREIGN KEY (MSSV) REFERENCES Login(Id) ON DELETE CASCADE;
IF OBJECT_ID('FK_HR_Login', 'F') IS NULL ALTER TABLE HR ADD CONSTRAINT FK_HR_Login FOREIGN KEY (MSGV) REFERENCES Login(Id) ON DELETE CASCADE;
IF OBJECT_ID('FK_Assign_HR', 'F') IS NULL ALTER TABLE Assign ADD CONSTRAINT FK_Assign_HR FOREIGN KEY (MSGV) REFERENCES HR(MSGV) ON DELETE CASCADE;
IF OBJECT_ID('FK_Assign_Course', 'F') IS NULL ALTER TABLE Assign ADD CONSTRAINT FK_Assign_Course FOREIGN KEY (MaMH) REFERENCES Course(MaMH) ON DELETE CASCADE;
IF OBJECT_ID('FK_DKMH_Student', 'F') IS NULL ALTER TABLE DKMH ADD CONSTRAINT FK_DKMH_Student FOREIGN KEY (MSSV) REFERENCES Student(MSSV) ON DELETE CASCADE;
IF OBJECT_ID('FK_DKMH_Course', 'F') IS NULL ALTER TABLE DKMH ADD CONSTRAINT FK_DKMH_Course FOREIGN KEY (MaMH) REFERENCES Course(MaMH) ON DELETE CASCADE;
IF OBJECT_ID('FK_Score_Student', 'F') IS NULL ALTER TABLE Score ADD CONSTRAINT FK_Score_Student FOREIGN KEY (MSSV) REFERENCES Student(MSSV) ON DELETE CASCADE;
IF OBJECT_ID('FK_Score_Course', 'F') IS NULL ALTER TABLE Score ADD CONSTRAINT FK_Score_Course FOREIGN KEY (MaMH) REFERENCES Course(MaMH) ON DELETE CASCADE;
GO

-- ==========================================================
-- 2. TẠO TRIGGER
-- ==========================================================
IF OBJECT_ID('TRG_Assign_Max5Courses', 'TR') IS NOT NULL DROP TRIGGER TRG_Assign_Max5Courses;
GO
CREATE TRIGGER TRG_Assign_Max5Courses ON Assign AFTER INSERT, UPDATE AS
BEGIN
    IF EXISTS (SELECT MSGV FROM Assign GROUP BY MSGV HAVING COUNT(MaMH) > 5)
    BEGIN
        RAISERROR (N'Lỗi: Một giảng viên chỉ được đảm nhiệm tối đa 5 môn học!', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;
GO

IF OBJECT_ID('TRG_Assign_HRDoesNotTeach', 'TR') IS NOT NULL DROP TRIGGER TRG_Assign_HRDoesNotTeach;
GO
CREATE TRIGGER TRG_Assign_HRDoesNotTeach ON Assign AFTER INSERT, UPDATE AS
BEGIN
    IF EXISTS (SELECT i.MSGV FROM inserted i JOIN HR h ON i.MSGV = h.MSGV WHERE h.Username LIKE 'hr%')
    BEGIN
        RAISERROR (N'Lỗi: Nhân sự quản trị (HR) không được phép phân công giảng dạy!', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;
GO

-- ==========================================================
-- 3. XÓA DỮ LIỆU CŨ VÀ CHÈN DỮ LIỆU
-- ==========================================================
DELETE FROM Assign; DELETE FROM DKMH; DELETE FROM Score; DELETE FROM Course; DELETE FROM Student; DELETE FROM HR; DELETE FROM Login;
GO

INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('ADMIN01', N'Vinh', N'Dương', 0, 'vido', 'e729364c43f9c41e2edbc1fca72761b81c7c5fd6203adda7925d1a3b65cf9aa5', 'duongduyvinh206@gmail.com', 1);
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('ADMIN02', N'Admin', N'Hai', 0, 'admin2', '201bce2458f00a54130c695ca8d1658319b32206d495adf175847b57bd4a4151', 'admin2@gmail.com', 1);
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110117', N'Nguyễn', N'Nuta', 1, 'nuta', '4cf34bb6209866d865cf1365a08909c550d22b3bf6d075adaa05d9ac30817a4e', '24110117@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110117', N'Nguyễn', N'Nuta', '2006-01-01', N'Nữ', '0901234567', N'Hồ Chí Minh', N'Hồ Chí Minh', '24110117@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110002', N'Huỳnh', N'Thu Hải', 1, 'sv2', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110002@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110002', N'Huỳnh', N'Thu Hải', '2006-05-15', N'Nam', '0934590114', N'Đồng Nai', N'Đồng Nai', '24110002@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110003', N'Phạm', N'Tấn Sơn', 1, 'sv3', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110003@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110003', N'Phạm', N'Tấn Sơn', '2006-05-15', N'Nam', '0963308638', N'Bình Dương', N'Bình Dương', '24110003@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110004', N'Lê', N'Xuân Cường', 1, 'sv4', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110004@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110004', N'Lê', N'Xuân Cường', '2006-05-15', N'Nữ', '0992597718', N'Hải Phòng', N'Hải Phòng', '24110004@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110005', N'Dương', N'Tấn Trang', 1, 'sv5', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110005@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110005', N'Dương', N'Tấn Trang', '2006-05-15', N'Nữ', '0986236267', N'Quảng Ninh', N'Quảng Ninh', '24110005@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110006', N'Lê', N'Ngọc Bình', 1, 'sv6', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110006@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110006', N'Lê', N'Ngọc Bình', '2006-05-15', N'Nam', '0998067434', N'Hải Phòng', N'Hải Phòng', '24110006@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110007', N'Hoàng', N'Đức Sơn', 1, 'sv7', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110007@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110007', N'Hoàng', N'Đức Sơn', '2006-05-15', N'Nữ', '0921276746', N'Hải Phòng', N'Hải Phòng', '24110007@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110008', N'Lê', N'Đức Uyên', 1, 'sv8', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110008@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110008', N'Lê', N'Đức Uyên', '2006-05-15', N'Nữ', '0943438898', N'Quảng Ninh', N'Quảng Ninh', '24110008@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110009', N'Lê', N'Thu Sơn', 1, 'sv9', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110009@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110009', N'Lê', N'Thu Sơn', '2006-05-15', N'Nam', '0920824633', N'Đồng Nai', N'Đồng Nai', '24110009@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110010', N'Ngô', N'Quang Lan', 1, 'sv10', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110010@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110010', N'Ngô', N'Quang Lan', '2006-05-15', N'Nam', '0950957544', N'Đồng Nai', N'Đồng Nai', '24110010@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110011', N'Trần', N'Thu Bình', 1, 'sv11', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110011@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110011', N'Trần', N'Thu Bình', '2006-05-15', N'Nữ', '0989244506', N'Cần Thơ', N'Cần Thơ', '24110011@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110012', N'Lê', N'Xuân Oanh', 1, 'sv12', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110012@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110012', N'Lê', N'Xuân Oanh', '2006-05-15', N'Nam', '0960937958', N'Nghệ An', N'Nghệ An', '24110012@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110013', N'Lê', N'Tấn Trang', 1, 'sv13', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110013@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110013', N'Lê', N'Tấn Trang', '2006-05-15', N'Nam', '0968317033', N'Hồ Chí Minh', N'Hồ Chí Minh', '24110013@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110014', N'Nguyễn', N'Bảo Cường', 1, 'sv14', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110014@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110014', N'Nguyễn', N'Bảo Cường', '2006-05-15', N'Nữ', '0978342160', N'Bình Dương', N'Bình Dương', '24110014@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110015', N'Phan', N'Ngọc Khang', 1, 'sv15', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110015@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110015', N'Phan', N'Ngọc Khang', '2006-05-15', N'Nam', '0949842666', N'Thanh Hóa', N'Thanh Hóa', '24110015@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110016', N'Hoàng', N'Văn Bình', 1, 'sv16', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110016@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110016', N'Hoàng', N'Văn Bình', '2006-05-15', N'Nam', '0926291319', N'Quảng Ninh', N'Quảng Ninh', '24110016@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110017', N'Võ', N'Minh Hải', 1, 'sv17', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110017@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110017', N'Võ', N'Minh Hải', '2006-05-15', N'Nữ', '0921614111', N'Hồ Chí Minh', N'Hồ Chí Minh', '24110017@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110018', N'Nguyễn', N'Thị Lan', 1, 'sv18', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110018@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110018', N'Nguyễn', N'Thị Lan', '2006-05-15', N'Nam', '0968852369', N'Đà Nẵng', N'Đà Nẵng', '24110018@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110019', N'Phan', N'Văn Dũng', 1, 'sv19', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110019@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110019', N'Phan', N'Văn Dũng', '2006-05-15', N'Nam', '0995651705', N'Hải Phòng', N'Hải Phòng', '24110019@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110020', N'Phạm', N'Thu Phong', 1, 'sv20', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110020@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110020', N'Phạm', N'Thu Phong', '2006-05-15', N'Nam', '0948767954', N'Đà Nẵng', N'Đà Nẵng', '24110020@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110021', N'Huỳnh', N'Hữu Lan', 1, 'sv21', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110021@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110021', N'Huỳnh', N'Hữu Lan', '2006-05-15', N'Nữ', '0911601420', N'Cần Thơ', N'Cần Thơ', '24110021@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110022', N'Nguyễn', N'Thu Hoa', 1, 'sv22', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110022@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110022', N'Nguyễn', N'Thu Hoa', '2006-05-15', N'Nam', '0924341488', N'Quảng Ninh', N'Quảng Ninh', '24110022@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110023', N'Hoàng', N'Thu Linh', 1, 'sv23', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110023@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110023', N'Hoàng', N'Thu Linh', '2006-05-15', N'Nam', '0947654858', N'Hồ Chí Minh', N'Hồ Chí Minh', '24110023@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110024', N'Huỳnh', N'Đức Em', 1, 'sv24', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110024@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110024', N'Huỳnh', N'Đức Em', '2006-05-15', N'Nam', '0930106162', N'Hải Phòng', N'Hải Phòng', '24110024@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110025', N'Lê', N'Văn Uyên', 1, 'sv25', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110025@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110025', N'Lê', N'Văn Uyên', '2006-05-15', N'Nam', '0940056018', N'Cần Thơ', N'Cần Thơ', '24110025@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110026', N'Vũ', N'Văn Phát', 1, 'sv26', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110026@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110026', N'Vũ', N'Văn Phát', '2006-05-15', N'Nữ', '0929869582', N'Nghệ An', N'Nghệ An', '24110026@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110027', N'Vũ', N'Thanh Hải', 1, 'sv27', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110027@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110027', N'Vũ', N'Thanh Hải', '2006-05-15', N'Nam', '0998150396', N'Hà Nội', N'Hà Nội', '24110027@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110028', N'Dương', N'Quang Sơn', 1, 'sv28', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110028@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110028', N'Dương', N'Quang Sơn', '2006-05-15', N'Nữ', '0958454900', N'Quảng Ninh', N'Quảng Ninh', '24110028@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110029', N'Trần', N'Ngọc Cường', 1, 'sv29', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110029@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110029', N'Trần', N'Ngọc Cường', '2006-05-15', N'Nam', '0969769848', N'Nghệ An', N'Nghệ An', '24110029@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110030', N'Hồ', N'Quang Phát', 1, 'sv30', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110030@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110030', N'Hồ', N'Quang Phát', '2006-05-15', N'Nam', '0919582433', N'Nghệ An', N'Nghệ An', '24110030@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110031', N'Phạm', N'Ngọc Anh', 1, 'sv31', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110031@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110031', N'Phạm', N'Ngọc Anh', '2006-05-15', N'Nam', '0966547280', N'Nghệ An', N'Nghệ An', '24110031@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110032', N'Hồ', N'Quang Trang', 1, 'sv32', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110032@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110032', N'Hồ', N'Quang Trang', '2006-05-15', N'Nữ', '0962489704', N'Bình Dương', N'Bình Dương', '24110032@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110033', N'Nguyễn', N'Thị Phong', 1, 'sv33', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110033@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110033', N'Nguyễn', N'Thị Phong', '2006-05-15', N'Nữ', '0989895605', N'Đà Nẵng', N'Đà Nẵng', '24110033@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110034', N'Lý', N'Minh Em', 1, 'sv34', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110034@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110034', N'Lý', N'Minh Em', '2006-05-15', N'Nữ', '0951311222', N'Cần Thơ', N'Cần Thơ', '24110034@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110035', N'Đặng', N'Bảo Trang', 1, 'sv35', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110035@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110035', N'Đặng', N'Bảo Trang', '2006-05-15', N'Nam', '0953285021', N'Hồ Chí Minh', N'Hồ Chí Minh', '24110035@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110036', N'Võ', N'Tấn Hoa', 1, 'sv36', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110036@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110036', N'Võ', N'Tấn Hoa', '2006-05-15', N'Nam', '0910571886', N'Đà Nẵng', N'Đà Nẵng', '24110036@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110037', N'Ngô', N'Hữu Oanh', 1, 'sv37', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110037@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110037', N'Ngô', N'Hữu Oanh', '2006-05-15', N'Nam', '0932550551', N'Quảng Ninh', N'Quảng Ninh', '24110037@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110038', N'Huỳnh', N'Thu Khang', 1, 'sv38', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110038@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110038', N'Huỳnh', N'Thu Khang', '2006-05-15', N'Nữ', '0997336371', N'Đà Nẵng', N'Đà Nẵng', '24110038@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110039', N'Dương', N'Quang Anh', 1, 'sv39', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110039@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110039', N'Dương', N'Quang Anh', '2006-05-15', N'Nam', '0938438058', N'Nghệ An', N'Nghệ An', '24110039@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110040', N'Đặng', N'Tấn Nga', 1, 'sv40', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110040@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110040', N'Đặng', N'Tấn Nga', '2006-05-15', N'Nam', '0941690896', N'Bình Dương', N'Bình Dương', '24110040@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110041', N'Phan', N'Hữu Nga', 1, 'sv41', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110041@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110041', N'Phan', N'Hữu Nga', '2006-05-15', N'Nữ', '0912814324', N'Quảng Ninh', N'Quảng Ninh', '24110041@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110042', N'Nguyễn', N'Văn Anh', 1, 'sv42', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110042@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110042', N'Nguyễn', N'Văn Anh', '2006-05-15', N'Nam', '0988872765', N'Cần Thơ', N'Cần Thơ', '24110042@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110043', N'Dương', N'Xuân Bình', 1, 'sv43', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110043@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110043', N'Dương', N'Xuân Bình', '2006-05-15', N'Nam', '0944153187', N'Quảng Ninh', N'Quảng Ninh', '24110043@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110044', N'Huỳnh', N'Ngọc Linh', 1, 'sv44', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110044@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110044', N'Huỳnh', N'Ngọc Linh', '2006-05-15', N'Nữ', '0954328986', N'Đà Nẵng', N'Đà Nẵng', '24110044@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110045', N'Hồ', N'Minh Hoa', 1, 'sv45', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110045@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110045', N'Hồ', N'Minh Hoa', '2006-05-15', N'Nam', '0982316898', N'Cần Thơ', N'Cần Thơ', '24110045@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110046', N'Lê', N'Đức Sơn', 1, 'sv46', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110046@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110046', N'Lê', N'Đức Sơn', '2006-05-15', N'Nam', '0968271232', N'Bình Dương', N'Bình Dương', '24110046@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110047', N'Lý', N'Bảo Vinh', 1, 'sv47', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110047@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110047', N'Lý', N'Bảo Vinh', '2006-05-15', N'Nam', '0934753790', N'Quảng Ninh', N'Quảng Ninh', '24110047@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110048', N'Phạm', N'Quang Uyên', 1, 'sv48', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110048@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110048', N'Phạm', N'Quang Uyên', '2006-05-15', N'Nữ', '0935394872', N'Hồ Chí Minh', N'Hồ Chí Minh', '24110048@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110049', N'Trần', N'Đức Phát', 1, 'sv49', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110049@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110049', N'Trần', N'Đức Phát', '2006-05-15', N'Nữ', '0988461302', N'Cần Thơ', N'Cần Thơ', '24110049@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110050', N'Võ', N'Thu Nam', 1, 'sv50', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110050@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110050', N'Võ', N'Thu Nam', '2006-05-15', N'Nam', '0944812109', N'Đà Nẵng', N'Đà Nẵng', '24110050@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110051', N'Phan', N'Minh Lan', 1, 'sv51', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110051@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110051', N'Phan', N'Minh Lan', '2006-05-15', N'Nam', '0935386955', N'Quảng Ninh', N'Quảng Ninh', '24110051@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110052', N'Lý', N'Tấn Sơn', 1, 'sv52', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110052@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110052', N'Lý', N'Tấn Sơn', '2006-05-15', N'Nữ', '0957505797', N'Đà Nẵng', N'Đà Nẵng', '24110052@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110053', N'Vũ', N'Hữu Em', 1, 'sv53', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110053@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110053', N'Vũ', N'Hữu Em', '2006-05-15', N'Nữ', '0945206388', N'Hà Nội', N'Hà Nội', '24110053@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110054', N'Bùi', N'Thu Cường', 1, 'sv54', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110054@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110054', N'Bùi', N'Thu Cường', '2006-05-15', N'Nữ', '0976856161', N'Cần Thơ', N'Cần Thơ', '24110054@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110055', N'Trần', N'Tấn Nam', 1, 'sv55', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110055@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110055', N'Trần', N'Tấn Nam', '2006-05-15', N'Nam', '0983826432', N'Hải Phòng', N'Hải Phòng', '24110055@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110056', N'Hoàng', N'Minh Trang', 1, 'sv56', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110056@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110056', N'Hoàng', N'Minh Trang', '2006-05-15', N'Nữ', '0972513178', N'Nghệ An', N'Nghệ An', '24110056@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110057', N'Huỳnh', N'Thu Uyên', 1, 'sv57', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110057@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110057', N'Huỳnh', N'Thu Uyên', '2006-05-15', N'Nam', '0934069127', N'Bình Dương', N'Bình Dương', '24110057@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110058', N'Phạm', N'Đức Trang', 1, 'sv58', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110058@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110058', N'Phạm', N'Đức Trang', '2006-05-15', N'Nữ', '0993981381', N'Nghệ An', N'Nghệ An', '24110058@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110059', N'Phan', N'Thu Phong', 1, 'sv59', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110059@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110059', N'Phan', N'Thu Phong', '2006-05-15', N'Nữ', '0954704304', N'Đồng Nai', N'Đồng Nai', '24110059@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110060', N'Lê', N'Hữu Dũng', 1, 'sv60', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110060@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110060', N'Lê', N'Hữu Dũng', '2006-05-15', N'Nữ', '0930331515', N'Đồng Nai', N'Đồng Nai', '24110060@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110061', N'Ngô', N'Minh Quyên', 1, 'sv61', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110061@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110061', N'Ngô', N'Minh Quyên', '2006-05-15', N'Nam', '0921309497', N'Đồng Nai', N'Đồng Nai', '24110061@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110062', N'Lý', N'Quang Sơn', 1, 'sv62', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110062@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110062', N'Lý', N'Quang Sơn', '2006-05-15', N'Nữ', '0989924797', N'Đồng Nai', N'Đồng Nai', '24110062@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110063', N'Phạm', N'Bảo Em', 1, 'sv63', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110063@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110063', N'Phạm', N'Bảo Em', '2006-05-15', N'Nữ', '0960626626', N'Nghệ An', N'Nghệ An', '24110063@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110064', N'Trần', N'Ngọc Hải', 1, 'sv64', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110064@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110064', N'Trần', N'Ngọc Hải', '2006-05-15', N'Nam', '0953468891', N'Hải Phòng', N'Hải Phòng', '24110064@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110065', N'Bùi', N'Minh Anh', 1, 'sv65', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110065@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110065', N'Bùi', N'Minh Anh', '2006-05-15', N'Nam', '0970489306', N'Quảng Ninh', N'Quảng Ninh', '24110065@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110066', N'Nguyễn', N'Tấn Bình', 1, 'sv66', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110066@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110066', N'Nguyễn', N'Tấn Bình', '2006-05-15', N'Nam', '0965074902', N'Hải Phòng', N'Hải Phòng', '24110066@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110067', N'Huỳnh', N'Bảo Phong', 1, 'sv67', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110067@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110067', N'Huỳnh', N'Bảo Phong', '2006-05-15', N'Nam', '0964613858', N'Quảng Ninh', N'Quảng Ninh', '24110067@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110068', N'Hoàng', N'Thị Phát', 1, 'sv68', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110068@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110068', N'Hoàng', N'Thị Phát', '2006-05-15', N'Nam', '0956782136', N'Cần Thơ', N'Cần Thơ', '24110068@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110069', N'Trần', N'Ngọc Vinh', 1, 'sv69', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110069@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110069', N'Trần', N'Ngọc Vinh', '2006-05-15', N'Nam', '0942040536', N'Cần Thơ', N'Cần Thơ', '24110069@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110070', N'Vũ', N'Văn Nam', 1, 'sv70', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110070@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110070', N'Vũ', N'Văn Nam', '2006-05-15', N'Nữ', '0998191201', N'Thanh Hóa', N'Thanh Hóa', '24110070@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110071', N'Hoàng', N'Thu Phát', 1, 'sv71', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110071@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110071', N'Hoàng', N'Thu Phát', '2006-05-15', N'Nam', '0943690504', N'Hải Phòng', N'Hải Phòng', '24110071@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110072', N'Phan', N'Minh Uyên', 1, 'sv72', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110072@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110072', N'Phan', N'Minh Uyên', '2006-05-15', N'Nam', '0927692886', N'Hải Phòng', N'Hải Phòng', '24110072@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110073', N'Huỳnh', N'Quang Oanh', 1, 'sv73', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110073@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110073', N'Huỳnh', N'Quang Oanh', '2006-05-15', N'Nam', '0938573898', N'Thanh Hóa', N'Thanh Hóa', '24110073@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110074', N'Vũ', N'Bảo Uyên', 1, 'sv74', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110074@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110074', N'Vũ', N'Bảo Uyên', '2006-05-15', N'Nam', '0986822183', N'Quảng Ninh', N'Quảng Ninh', '24110074@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110075', N'Lý', N'Minh Em', 1, 'sv75', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110075@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110075', N'Lý', N'Minh Em', '2006-05-15', N'Nữ', '0973493356', N'Cần Thơ', N'Cần Thơ', '24110075@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110076', N'Hoàng', N'Văn Khang', 1, 'sv76', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110076@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110076', N'Hoàng', N'Văn Khang', '2006-05-15', N'Nam', '0965732828', N'Bình Dương', N'Bình Dương', '24110076@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110077', N'Trần', N'Bảo Hoa', 1, 'sv77', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110077@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110077', N'Trần', N'Bảo Hoa', '2006-05-15', N'Nam', '0935859175', N'Đà Nẵng', N'Đà Nẵng', '24110077@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110078', N'Hoàng', N'Bảo Nga', 1, 'sv78', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110078@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110078', N'Hoàng', N'Bảo Nga', '2006-05-15', N'Nam', '0974495672', N'Hải Phòng', N'Hải Phòng', '24110078@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110079', N'Hồ', N'Hữu Em', 1, 'sv79', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110079@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110079', N'Hồ', N'Hữu Em', '2006-05-15', N'Nam', '0915073927', N'Đà Nẵng', N'Đà Nẵng', '24110079@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110080', N'Lý', N'Tấn Quyên', 1, 'sv80', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110080@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110080', N'Lý', N'Tấn Quyên', '2006-05-15', N'Nữ', '0955072182', N'Hà Nội', N'Hà Nội', '24110080@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110081', N'Phan', N'Ngọc Cường', 1, 'sv81', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110081@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110081', N'Phan', N'Ngọc Cường', '2006-05-15', N'Nữ', '0920546267', N'Cần Thơ', N'Cần Thơ', '24110081@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110082', N'Lý', N'Đức Em', 1, 'sv82', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110082@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110082', N'Lý', N'Đức Em', '2006-05-15', N'Nam', '0971304439', N'Hồ Chí Minh', N'Hồ Chí Minh', '24110082@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110083', N'Đặng', N'Bảo Oanh', 1, 'sv83', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110083@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110083', N'Đặng', N'Bảo Oanh', '2006-05-15', N'Nam', '0918398767', N'Bình Dương', N'Bình Dương', '24110083@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110084', N'Bùi', N'Quang Bình', 1, 'sv84', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110084@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110084', N'Bùi', N'Quang Bình', '2006-05-15', N'Nữ', '0961745406', N'Hà Nội', N'Hà Nội', '24110084@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110085', N'Phan', N'Minh Quyên', 1, 'sv85', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110085@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110085', N'Phan', N'Minh Quyên', '2006-05-15', N'Nữ', '0950182851', N'Hà Nội', N'Hà Nội', '24110085@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110086', N'Trần', N'Ngọc Khang', 1, 'sv86', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110086@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110086', N'Trần', N'Ngọc Khang', '2006-05-15', N'Nữ', '0948477150', N'Hải Phòng', N'Hải Phòng', '24110086@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110087', N'Lê', N'Hữu Oanh', 1, 'sv87', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110087@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110087', N'Lê', N'Hữu Oanh', '2006-05-15', N'Nữ', '0929179122', N'Cần Thơ', N'Cần Thơ', '24110087@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110088', N'Bùi', N'Thanh Dũng', 1, 'sv88', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110088@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110088', N'Bùi', N'Thanh Dũng', '2006-05-15', N'Nam', '0915347341', N'Đà Nẵng', N'Đà Nẵng', '24110088@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110089', N'Võ', N'Xuân Oanh', 1, 'sv89', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110089@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110089', N'Võ', N'Xuân Oanh', '2006-05-15', N'Nam', '0921295042', N'Hải Phòng', N'Hải Phòng', '24110089@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110090', N'Dương', N'Minh Cường', 1, 'sv90', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110090@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110090', N'Dương', N'Minh Cường', '2006-05-15', N'Nữ', '0996892011', N'Đồng Nai', N'Đồng Nai', '24110090@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110091', N'Dương', N'Xuân Oanh', 1, 'sv91', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110091@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110091', N'Dương', N'Xuân Oanh', '2006-05-15', N'Nam', '0975442310', N'Bình Dương', N'Bình Dương', '24110091@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110092', N'Hồ', N'Quang Vinh', 1, 'sv92', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110092@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110092', N'Hồ', N'Quang Vinh', '2006-05-15', N'Nam', '0990285875', N'Thanh Hóa', N'Thanh Hóa', '24110092@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110093', N'Hồ', N'Thị Trang', 1, 'sv93', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110093@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110093', N'Hồ', N'Thị Trang', '2006-05-15', N'Nam', '0998826865', N'Đà Nẵng', N'Đà Nẵng', '24110093@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110094', N'Đặng', N'Thị Bình', 1, 'sv94', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110094@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110094', N'Đặng', N'Thị Bình', '2006-05-15', N'Nữ', '0980674173', N'Cần Thơ', N'Cần Thơ', '24110094@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110095', N'Trần', N'Bảo Hải', 1, 'sv95', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110095@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110095', N'Trần', N'Bảo Hải', '2006-05-15', N'Nam', '0948012755', N'Nghệ An', N'Nghệ An', '24110095@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110096', N'Lê', N'Minh Dũng', 1, 'sv96', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110096@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110096', N'Lê', N'Minh Dũng', '2006-05-15', N'Nữ', '0918642549', N'Hải Phòng', N'Hải Phòng', '24110096@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110097', N'Lý', N'Minh Hoa', 1, 'sv97', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110097@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110097', N'Lý', N'Minh Hoa', '2006-05-15', N'Nữ', '0945044264', N'Quảng Ninh', N'Quảng Ninh', '24110097@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110098', N'Vũ', N'Hữu Uyên', 1, 'sv98', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110098@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110098', N'Vũ', N'Hữu Uyên', '2006-05-15', N'Nữ', '0986153857', N'Hồ Chí Minh', N'Hồ Chí Minh', '24110098@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110099', N'Hoàng', N'Hữu Hoa', 1, 'sv99', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110099@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110099', N'Hoàng', N'Hữu Hoa', '2006-05-15', N'Nữ', '0913193168', N'Thanh Hóa', N'Thanh Hóa', '24110099@student.hcmute.edu.vn');
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('24110100', N'Đỗ', N'Hữu Trang', 1, 'sv100', '87cdfbace670d6d44af234906b12237b700da41cf1e7edd23124429e43f2cfc9', '24110100@student.hcmute.edu.vn', 1);
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES ('24110100', N'Đỗ', N'Hữu Trang', '2006-05-15', N'Nam', '0951648075', N'Hà Nội', N'Hà Nội', '24110100@student.hcmute.edu.vn');
GO

INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('HR_001', N'Trần', N'Nhân Sự', 2, 'hr', '35d61dd8ed36ae0e9275a4629a571c676d1469b771b6776e2f19f1e7e5bb1984', '24110124@student.hcmute.edu.vn', 1);
INSERT INTO HR (MSGV, Fname, Lname, Position, Username, Pass, Email, Valid) VALUES ('HR_001', N'Trần', N'Nhân Sự', 2, 'hr', '35d61dd8ed36ae0e9275a4629a571c676d1469b771b6776e2f19f1e7e5bb1984', '24110124@student.hcmute.edu.vn', 1);
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('HR_002', N'Vũ', N'Thu Uyên', 2, 'hr2', '35d61dd8ed36ae0e9275a4629a571c676d1469b771b6776e2f19f1e7e5bb1984', 'hr2@hcmute.edu.vn', 1);
INSERT INTO HR (MSGV, Fname, Lname, Position, Username, Pass, Email, Valid) VALUES ('HR_002', N'Vũ', N'Thu Uyên', 2, 'hr2', '35d61dd8ed36ae0e9275a4629a571c676d1469b771b6776e2f19f1e7e5bb1984', 'hr2@hcmute.edu.vn', 1);
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('HR_003', N'Ngô', N'Bảo Khang', 2, 'hr3', '35d61dd8ed36ae0e9275a4629a571c676d1469b771b6776e2f19f1e7e5bb1984', 'hr3@hcmute.edu.vn', 1);
INSERT INTO HR (MSGV, Fname, Lname, Position, Username, Pass, Email, Valid) VALUES ('HR_003', N'Ngô', N'Bảo Khang', 2, 'hr3', '35d61dd8ed36ae0e9275a4629a571c676d1469b771b6776e2f19f1e7e5bb1984', 'hr3@hcmute.edu.vn', 1);
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('HR_004', N'Hoàng', N'Thị Hoa', 2, 'hr4', '35d61dd8ed36ae0e9275a4629a571c676d1469b771b6776e2f19f1e7e5bb1984', 'hr4@hcmute.edu.vn', 1);
INSERT INTO HR (MSGV, Fname, Lname, Position, Username, Pass, Email, Valid) VALUES ('HR_004', N'Hoàng', N'Thị Hoa', 2, 'hr4', '35d61dd8ed36ae0e9275a4629a571c676d1469b771b6776e2f19f1e7e5bb1984', 'hr4@hcmute.edu.vn', 1);
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('HR_005', N'Vũ', N'Đức Linh', 2, 'hr5', '35d61dd8ed36ae0e9275a4629a571c676d1469b771b6776e2f19f1e7e5bb1984', 'hr5@hcmute.edu.vn', 1);
INSERT INTO HR (MSGV, Fname, Lname, Position, Username, Pass, Email, Valid) VALUES ('HR_005', N'Vũ', N'Đức Linh', 2, 'hr5', '35d61dd8ed36ae0e9275a4629a571c676d1469b771b6776e2f19f1e7e5bb1984', 'hr5@hcmute.edu.vn', 1);
GO

INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('GV_001', N'Trần', N'Ngọc Trang', 2, 'nguyenthia', '6e22b739cf7da6de21bef7a91f0fd1ec7836d47137e09a90a45e012aff8372ce', 'nguyenthia@hcmute.edu.vn', 1);
INSERT INTO HR (MSGV, Fname, Lname, Position, Username, Pass, Email, Valid) VALUES ('GV_001', N'Trần', N'Ngọc Trang', 2, 'nguyenthia', '6e22b739cf7da6de21bef7a91f0fd1ec7836d47137e09a90a45e012aff8372ce', 'nguyenthia@hcmute.edu.vn', 1);
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('GV_002', N'Phạm', N'Bảo Uyên', 2, 'tranthib', '6e22b739cf7da6de21bef7a91f0fd1ec7836d47137e09a90a45e012aff8372ce', 'tranthib@hcmute.edu.vn', 1);
INSERT INTO HR (MSGV, Fname, Lname, Position, Username, Pass, Email, Valid) VALUES ('GV_002', N'Phạm', N'Bảo Uyên', 2, 'tranthib', '6e22b739cf7da6de21bef7a91f0fd1ec7836d47137e09a90a45e012aff8372ce', 'tranthib@hcmute.edu.vn', 1);
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('GV_003', N'Bùi', N'Thu Anh', 2, 'gv3', '6e22b739cf7da6de21bef7a91f0fd1ec7836d47137e09a90a45e012aff8372ce', 'gv3@hcmute.edu.vn', 1);
INSERT INTO HR (MSGV, Fname, Lname, Position, Username, Pass, Email, Valid) VALUES ('GV_003', N'Bùi', N'Thu Anh', 2, 'gv3', '6e22b739cf7da6de21bef7a91f0fd1ec7836d47137e09a90a45e012aff8372ce', 'gv3@hcmute.edu.vn', 1);
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('GV_004', N'Đặng', N'Bảo Nga', 2, 'gv4', '6e22b739cf7da6de21bef7a91f0fd1ec7836d47137e09a90a45e012aff8372ce', 'gv4@hcmute.edu.vn', 1);
INSERT INTO HR (MSGV, Fname, Lname, Position, Username, Pass, Email, Valid) VALUES ('GV_004', N'Đặng', N'Bảo Nga', 2, 'gv4', '6e22b739cf7da6de21bef7a91f0fd1ec7836d47137e09a90a45e012aff8372ce', 'gv4@hcmute.edu.vn', 1);
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('GV_005', N'Đỗ', N'Minh Nga', 2, 'gv5', '6e22b739cf7da6de21bef7a91f0fd1ec7836d47137e09a90a45e012aff8372ce', 'gv5@hcmute.edu.vn', 1);
INSERT INTO HR (MSGV, Fname, Lname, Position, Username, Pass, Email, Valid) VALUES ('GV_005', N'Đỗ', N'Minh Nga', 2, 'gv5', '6e22b739cf7da6de21bef7a91f0fd1ec7836d47137e09a90a45e012aff8372ce', 'gv5@hcmute.edu.vn', 1);
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('GV_006', N'Ngô', N'Minh Cường', 2, 'gv6', '6e22b739cf7da6de21bef7a91f0fd1ec7836d47137e09a90a45e012aff8372ce', 'gv6@hcmute.edu.vn', 1);
INSERT INTO HR (MSGV, Fname, Lname, Position, Username, Pass, Email, Valid) VALUES ('GV_006', N'Ngô', N'Minh Cường', 2, 'gv6', '6e22b739cf7da6de21bef7a91f0fd1ec7836d47137e09a90a45e012aff8372ce', 'gv6@hcmute.edu.vn', 1);
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('GV_007', N'Hồ', N'Hữu Oanh', 2, 'gv7', '6e22b739cf7da6de21bef7a91f0fd1ec7836d47137e09a90a45e012aff8372ce', 'gv7@hcmute.edu.vn', 1);
INSERT INTO HR (MSGV, Fname, Lname, Position, Username, Pass, Email, Valid) VALUES ('GV_007', N'Hồ', N'Hữu Oanh', 2, 'gv7', '6e22b739cf7da6de21bef7a91f0fd1ec7836d47137e09a90a45e012aff8372ce', 'gv7@hcmute.edu.vn', 1);
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('GV_008', N'Vũ', N'Bảo Dũng', 2, 'gv8', '6e22b739cf7da6de21bef7a91f0fd1ec7836d47137e09a90a45e012aff8372ce', 'gv8@hcmute.edu.vn', 1);
INSERT INTO HR (MSGV, Fname, Lname, Position, Username, Pass, Email, Valid) VALUES ('GV_008', N'Vũ', N'Bảo Dũng', 2, 'gv8', '6e22b739cf7da6de21bef7a91f0fd1ec7836d47137e09a90a45e012aff8372ce', 'gv8@hcmute.edu.vn', 1);
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('GV_009', N'Dương', N'Bảo Bình', 2, 'gv9', '6e22b739cf7da6de21bef7a91f0fd1ec7836d47137e09a90a45e012aff8372ce', 'gv9@hcmute.edu.vn', 1);
INSERT INTO HR (MSGV, Fname, Lname, Position, Username, Pass, Email, Valid) VALUES ('GV_009', N'Dương', N'Bảo Bình', 2, 'gv9', '6e22b739cf7da6de21bef7a91f0fd1ec7836d47137e09a90a45e012aff8372ce', 'gv9@hcmute.edu.vn', 1);
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('GV_010', N'Lý', N'Đức Phong', 2, 'gv10', '6e22b739cf7da6de21bef7a91f0fd1ec7836d47137e09a90a45e012aff8372ce', 'gv10@hcmute.edu.vn', 1);
INSERT INTO HR (MSGV, Fname, Lname, Position, Username, Pass, Email, Valid) VALUES ('GV_010', N'Lý', N'Đức Phong', 2, 'gv10', '6e22b739cf7da6de21bef7a91f0fd1ec7836d47137e09a90a45e012aff8372ce', 'gv10@hcmute.edu.vn', 1);
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('GV_011', N'Bùi', N'Hữu Oanh', 2, 'gv11', '6e22b739cf7da6de21bef7a91f0fd1ec7836d47137e09a90a45e012aff8372ce', 'gv11@hcmute.edu.vn', 1);
INSERT INTO HR (MSGV, Fname, Lname, Position, Username, Pass, Email, Valid) VALUES ('GV_011', N'Bùi', N'Hữu Oanh', 2, 'gv11', '6e22b739cf7da6de21bef7a91f0fd1ec7836d47137e09a90a45e012aff8372ce', 'gv11@hcmute.edu.vn', 1);
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('GV_012', N'Ngô', N'Thanh Sơn', 2, 'gv12', '6e22b739cf7da6de21bef7a91f0fd1ec7836d47137e09a90a45e012aff8372ce', 'gv12@hcmute.edu.vn', 1);
INSERT INTO HR (MSGV, Fname, Lname, Position, Username, Pass, Email, Valid) VALUES ('GV_012', N'Ngô', N'Thanh Sơn', 2, 'gv12', '6e22b739cf7da6de21bef7a91f0fd1ec7836d47137e09a90a45e012aff8372ce', 'gv12@hcmute.edu.vn', 1);
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('GV_013', N'Huỳnh', N'Minh Em', 2, 'gv13', '6e22b739cf7da6de21bef7a91f0fd1ec7836d47137e09a90a45e012aff8372ce', 'gv13@hcmute.edu.vn', 1);
INSERT INTO HR (MSGV, Fname, Lname, Position, Username, Pass, Email, Valid) VALUES ('GV_013', N'Huỳnh', N'Minh Em', 2, 'gv13', '6e22b739cf7da6de21bef7a91f0fd1ec7836d47137e09a90a45e012aff8372ce', 'gv13@hcmute.edu.vn', 1);
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('GV_014', N'Vũ', N'Quang Em', 2, 'gv14', '6e22b739cf7da6de21bef7a91f0fd1ec7836d47137e09a90a45e012aff8372ce', 'gv14@hcmute.edu.vn', 1);
INSERT INTO HR (MSGV, Fname, Lname, Position, Username, Pass, Email, Valid) VALUES ('GV_014', N'Vũ', N'Quang Em', 2, 'gv14', '6e22b739cf7da6de21bef7a91f0fd1ec7836d47137e09a90a45e012aff8372ce', 'gv14@hcmute.edu.vn', 1);
INSERT INTO Login (Id, Fname, Lname, Position, UserName, Password, Email, Valid) VALUES ('GV_015', N'Lý', N'Thanh Cường', 2, 'gv15', '6e22b739cf7da6de21bef7a91f0fd1ec7836d47137e09a90a45e012aff8372ce', 'gv15@hcmute.edu.vn', 1);
INSERT INTO HR (MSGV, Fname, Lname, Position, Username, Pass, Email, Valid) VALUES ('GV_015', N'Lý', N'Thanh Cường', 2, 'gv15', '6e22b739cf7da6de21bef7a91f0fd1ec7836d47137e09a90a45e012aff8372ce', 'gv15@hcmute.edu.vn', 1);
GO

INSERT INTO Course (MaMH, TenMH, SoTC, Tuan, HocKy, Mota) VALUES ('MATH101', N'Toán Cao Cấp 1', 3, 15, 1, N'');
INSERT INTO Course (MaMH, TenMH, SoTC, Tuan, HocKy, Mota) VALUES ('PHYS101', N'Vật Lý Đại Cương', 3, 15, 1, N'');
INSERT INTO Course (MaMH, TenMH, SoTC, Tuan, HocKy, Mota) VALUES ('CS101', N'Nhập Môn Lập Trình', 4, 15, 1, N'');
INSERT INTO Course (MaMH, TenMH, SoTC, Tuan, HocKy, Mota) VALUES ('CS102', N'Cấu Trúc Dữ Liệu', 4, 15, 1, N'');
INSERT INTO Course (MaMH, TenMH, SoTC, Tuan, HocKy, Mota) VALUES ('ENG101', N'Tiếng Anh 1', 2, 15, 1, N'');
INSERT INTO Course (MaMH, TenMH, SoTC, Tuan, HocKy, Mota) VALUES ('ENG102', N'Tiếng Anh 2', 2, 15, 1, N'');
INSERT INTO Course (MaMH, TenMH, SoTC, Tuan, HocKy, Mota) VALUES ('WEB101', N'Lập Trình Web', 3, 15, 1, N'');
INSERT INTO Course (MaMH, TenMH, SoTC, Tuan, HocKy, Mota) VALUES ('DB101', N'Cơ Sở Dữ Liệu', 3, 15, 1, N'');
INSERT INTO Course (MaMH, TenMH, SoTC, Tuan, HocKy, Mota) VALUES ('AI101', N'Trí Tuệ Nhân Tạo', 3, 15, 1, N'');
INSERT INTO Course (MaMH, TenMH, SoTC, Tuan, HocKy, Mota) VALUES ('NET101', N'Mạng Máy Tính', 3, 15, 1, N'');
INSERT INTO Course (MaMH, TenMH, SoTC, Tuan, HocKy, Mota) VALUES ('OS101', N'Hệ Điều Hành', 3, 15, 1, N'');
INSERT INTO Course (MaMH, TenMH, SoTC, Tuan, HocKy, Mota) VALUES ('SE101', N'Công Nghệ Phần Mềm', 3, 15, 1, N'');
GO

INSERT INTO Assign (MSGV, MaMH) VALUES ('GV_001', 'MATH101');
INSERT INTO Assign (MSGV, MaMH) VALUES ('GV_001', 'PHYS101');
INSERT INTO Assign (MSGV, MaMH) VALUES ('GV_001', 'CS101');
INSERT INTO Assign (MSGV, MaMH) VALUES ('GV_001', 'CS102');
INSERT INTO Assign (MSGV, MaMH) VALUES ('GV_001', 'ENG101');
INSERT INTO Assign (MSGV, MaMH) VALUES ('GV_002', 'ENG102');
INSERT INTO Assign (MSGV, MaMH) VALUES ('GV_002', 'WEB101');
INSERT INTO Assign (MSGV, MaMH) VALUES ('GV_002', 'DB101');
INSERT INTO Assign (MSGV, MaMH) VALUES ('GV_002', 'AI101');
INSERT INTO Assign (MSGV, MaMH) VALUES ('GV_002', 'NET101');
GO
PRINT N'Thêm ràng buộc chặt chẽ và chèn hàng loạt dữ liệu mẫu thành công!';
