import Describe from "../../components/user/user_describe";
import Footer from "../../components/footer";
import Hero from "../../components/user/user_hero";
import NavBar from "../../components/nav";
import Steps from "../../components/user/user_steps";

function user_home(){
    return(
        <>
        <NavBar/>
        <Hero />
        <div className="container w-100 my-4">
        <Describe/>
        <Steps/>
        </div>
        <Footer/>
        </>
    );
}
export default user_home;