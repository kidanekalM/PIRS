import { Link } from 'react-router-dom';
import '../../component_styles/hero.css';
const Hero = () => {
    return ( 
        <div>
        <section className="light hero">
          <div className="heroInner">
            <span>
              <h1>Report, Gain Ratings and Expect Support in a Short Time</h1>
              <Link to="/signupasuser">
              <p className="btn btn-light">
                Report Now
              </p>
              </Link>
            </span>
          </div>
        </section>
      </div>
     );
}
 
export default Hero;