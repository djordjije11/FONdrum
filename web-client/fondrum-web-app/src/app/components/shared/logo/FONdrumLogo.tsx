import FONdrumLogoImg from "../../../../assets/logo/FONdrumLogoCropped.jpg";

export default function FONdrumLogo() {
  return (
    <div className="h-full flex items-center">
      <img
        src={FONdrumLogoImg}
        className="h-full"
        alt="FONdrum Logo"
        loading="lazy"
      />
    </div>
  );
}
