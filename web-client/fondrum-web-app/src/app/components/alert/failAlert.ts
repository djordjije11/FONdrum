import Swal from "sweetalert2";

export default function failAlert(title: string, text: string) {
  Swal.fire({
    icon: "error",
    title,
    text,
  });
}
