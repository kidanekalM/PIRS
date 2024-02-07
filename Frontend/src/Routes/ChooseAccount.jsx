import { Link } from "react-router-dom";
const ChooseAccount = () => {
    return ( 
        <>
            <div className="row">
                <div className="col border"><Link to="../signinasuser" replace><button className="btn">User</button></Link></div>
                <div className="col border"><Link to="../signinascontractor" replace><button className="btn">Contractor</button></Link></div>
                <div className="col border"><Link to="../signinascompany" replace><button className="btn">Company</button></Link></div>
            </div>
        </>
     );
}
 
export default ChooseAccount;