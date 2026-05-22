interface Props{
    title:string;
    image:string;
    onClick?:()=> void;
}

export const MovieCard = ({ title, image , onClick}:Props) => {
    return (
        <div
            onClick={onClick}
            className="bg-zinc-900/80 backdrop-blur-md rounded-3xl overflow-hidden shadow-2xl cursor-pointer hover:scale-105 transition duration-50"
        >
            <img
                src={image}
                alt={title}
                className="w-full h-[420px] object-cover"
            />
            <div className="p-5 flex justify-start">
                <h2 className="text-white text-2xl font-semibold">{title} -</h2>
                <p className="text-red-700 mt-1 text-xl font-semibold font-sans pl-2">NEW</p>
            </div>
        </div>
    );
}