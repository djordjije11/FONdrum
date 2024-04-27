import AboutUsImg from "../../../assets/about-us/about-us-img.jpg";

export default function AboutUs() {
  const aboutUsText = `Lorem ipsum dolor sit amet consectetur adipisicing elit. Animi,
  ratione libero. Sed dicta consequatur animi error nisi, provident,
  doloremque eligendi iste suscipit doloribus nobis aut, dolorum quasi
  possimus ipsa. Aspernatur. Lorem ipsum dolor sit, amet consectetur
  adipisicing elit. Eaque corrupti molestias distinctio hic nihil iure
  ullam architecto inventore ratione! Nemo iusto delectus quidem tenetur
  nesciunt, aperiam, tempora facere hic nostrum iure inventore amet quae
  aut quo sunt reprehenderit placeat perferendis fugiat libero officia
  quaerat recusandae! Ex pariatur, cupiditate voluptates officiis maxime
  adipisci vero. Rem, assumenda consequatur numquam animi a ipsam
  impedit similique blanditiis nostrum possimus iure facere doloribus
  aliquam aspernatur ullam reprehenderit velit.`;

  return (
    <div className="w-2/3 h-fit flex justify-between items-end gap-10">
      <div className="flex flex-col items-center gap-4">
        <h2 className="text-2xl text-blue-gray-100 font-custom--exo2">
          O nama
        </h2>
        <p className="text-gray-50 border-4 border-solid border-blue-gray-700 rounded-lg p-4">
          {aboutUsText}
        </p>
      </div>
      <div className="min-w-96">
        <img
          src={AboutUsImg}
          alt="About us"
          className="border-8 border-solid border-blue-gray-800 rounded-md"
        />
      </div>
    </div>
  );
}
