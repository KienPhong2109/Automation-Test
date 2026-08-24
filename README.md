E-Commerce Automation Testing (C# & Selenium)

Một dự án kiểm thử tự động (Automation Testing) dành cho website thương mại điện tử [Automation Exercise](https://automationexercise.com/). 

Công nghệ sử dụng

Ngôn ngữ: C#

Framework giao diện: Windows Forms (WinForms)

Thư viện kiểm thử: Selenium WebDriver

Công cụ hỗ trợ (AI): Ứng dụng AI (Claude, ChatGPT, Gemini) trong việc phân tích luồng, hỗ trợ sinh mã (generate code) script test và tạo dữ liệu kiểm thử (test data).

Các kịch bản kiểm thử (Test Cases) đã triển khai

Dự án bao phủ các luồng chức năng quan trọng nhất của một hệ thống E-commerce, bao gồm:
Authentication (Xác thực người dùng):
  * Đăng ký tài khoản mới thành công.
  * Đăng ký với Email đã tồn tại (Register Exist).
  * Đăng nhập thành công.
  * Đăng nhập thất bại (Sai thông tin/Login fail).
  * Đăng xuất (Logout).
* **Customer Service (Chăm sóc khách hàng):**
  * Gửi form liên hệ (Contact Us) thành công.

## ⚙️ Hướng dẫn cài đặt và chạy (How to run)
1. **Yêu cầu hệ thống:**
   * Cài đặt [Visual Studio](https://visualstudio.microsoft.com/) (Khuyến nghị bản 2019 hoặc mới hơn).
   * Trình duyệt Google Chrome.
2. **Cài đặt dự án:**
   * Clone repository này về máy:
     ```bash
     git clone [https://github.com/KienPhong2109/Automation-Test.git](https://github.com/KienPhong2109/Automation-Test.git)
     ```
   * Mở file `.sln` bằng Visual Studio.
   * Chờ Visual Studio tự động khôi phục các gói NuGet (Selenium WebDriver).
3. **Khởi chạy:**
   * Nhấn `F5` hoặc nút `Start` trên Visual Studio để chạy ứng dụng WinForms.
   * Giao diện Control Panel sẽ hiện ra, cho phép bạn chọn kịch bản và tự động chạy trình duyệt để thực thi các bước kiểm thử.

## 👤 Thông tin tác giả
* **Họ và tên:** Chung Kiến Phong
* **Vị trí ứng tuyển:** Thực tập sinh Kiểm thử phần mềm (QA/Tester Intern)
* **Email:** chungkienphong.hcm@gmail.com
