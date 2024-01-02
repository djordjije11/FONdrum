import Swal from "sweetalert2";

export default function successAlert(title: string) {
  Swal.fire({
    icon: "success",
    title,
    showConfirmButton: false,
    timer: 1000,
  });
}
