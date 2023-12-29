import FONdrumLogoJpg from "../../../../assets/logo/FONdrumLogoCropped.jpg";

export default function FONdrumLogo() {
  return (
    <div className="h-full flex items-center">
      <img
        src={FONdrumLogoJpg}
        className="h-full"
        alt="FONdrum Logo"
        loading="lazy"
      />
    </div>
  );
}
