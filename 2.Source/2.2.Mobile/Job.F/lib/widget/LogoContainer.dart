import 'dart:math';
import 'package:flutter/material.dart';
import 'package:google_fonts/google_fonts.dart';

class LogoContainer extends StatelessWidget {
  const LogoContainer({Key key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Container(
        child:  RichText(
          textAlign: TextAlign.center,
          text: TextSpan(
              text: 'JOB.',
              style: GoogleFonts.portLligatSans(
                textStyle: Theme.of(context).textTheme.display1,
                fontSize: 45,
                fontWeight: FontWeight.w700,
                color: Colors.pink,
              ),
              children: [
                TextSpan(
                  text: 'F',
                  style: TextStyle(color: Colors.amberAccent, fontWeight: FontWeight.w700,fontSize: 45),
                )
              ]),
        )
    );
  }
}